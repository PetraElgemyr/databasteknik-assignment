using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Projects;
using Business.Models.Users;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Collections.Generic;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository,
    IProjectScheduleRepository projectScheduleRepository,
    ICustomerRepository customerRepository,
    IStatusTypeRepository statusTypeRepository,
    IUserRepository userRepository,
    IProjectServiceRepository projectServiceRepository, IServiceRepository serviceRepository
    ) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IProjectScheduleRepository _projectScheduleRepository = projectScheduleRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IProjectServiceRepository _projectServiceRepository = projectServiceRepository;
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    public async Task<ResponseResult<IEnumerable<ListProject?>>> GetAllProjectsAsync()
    {
        try
        {
            var entities = await _projectRepository.GetAllAsync();
            var listProjects = entities.Select(ProjectFactory.CreateListProjectFromEntity);

            return ResponseResult<IEnumerable<ListProject?>>.Ok("All projects fetched successfully!", listProjects);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ListProject?>>.Error($"Something went wrong when trying to fetch all projects. {ex.Message}");
        }
    }
    public async Task<ResponseResult<ProjectWithDetails?>> GetOneProjectByIdAsync(int projectId)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == projectId);

            if (projectEntity == null)
                return ResponseResult<ProjectWithDetails?>.NotFound($"No project with id {projectId} could be found.");

            var projectWithDetails = ProjectFactory.CreateProjectWithDetailsFromEntity(projectEntity);
            return ResponseResult<ProjectWithDetails?>.Ok("Project with details successfully fetched!", projectWithDetails);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ProjectWithDetails?>.Error($"Something went wrong when fetching project with id {projectId}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ListProject?>>> GetAllProjectsByCustomerIdAsync(int customerId)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == customerId);
            if (customer == null)
                return ResponseResult<IEnumerable<ListProject?>>.NotFound($"No customer with id: {customerId} exists.");

            var entities = await _projectRepository.GetAllProjectByCustomerIdAsync(customerId);
            var listProjectsForCustomer = entities!.Select(ProjectFactory.CreateListProjectFromEntity);

            return ResponseResult<IEnumerable<ListProject?>>.Ok($"All projects for customer with id: {customerId} successfully fetched.", listProjectsForCustomer);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ListProject?>>.Error($"Something went wrong when trying to fetch the projects for the customer with id: {customerId}. {ex.Message}");
        }
    }


    public async Task<ResponseResult<Project?>> CreateNewProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == form.CustomerId);
            var statusType = await _statusTypeRepository.GetAsync(s => s.Id == form.StatusTypeId);
            var user = await _userRepository.GetAsync(u => u.Id == form.UserId);
            var service = await _serviceRepository.GetAsync(s => s.Id == form.ProjectService.ServiceId);

            if (service == null)
                return ResponseResult<Project?>.BadRequest("No service with that id exists. Could not create project with the provided service");
            if (customer == null)
                return ResponseResult<Project?>.BadRequest("No customer with that id exists. Could not create project with the provided customer");
            if (statusType == null)
                return ResponseResult<Project?>.BadRequest("No statusType with that id exists. Could not create project with an invalid status!");
            if (user == null)
                return ResponseResult<Project?>.BadRequest("No user with that id exists. Could not create project with invalid user.");

            var scheduleEntityToAdd = ProjectScheduleFactory.CreateEntityFromRegistrationForm(form.ProjectSchedule);
            if (scheduleEntityToAdd == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the schedule entity");

            var createdScheduleWithId = await _projectScheduleRepository.AddAsync(scheduleEntityToAdd);

            if (createdScheduleWithId == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the date schedule. Project could not be created");

            var projectEntityWithSchedule = ProjectFactory.CreateEntityFromRegistrationForm(form, createdScheduleWithId);
            if (projectEntityWithSchedule == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project entity with schedule");
            var createdProjectEntityWithId = await _projectRepository.AddAsync(projectEntityWithSchedule);

            if (createdProjectEntityWithId == null)
            {
                // ta bort skapat schema om projekt failar med att skapa mitt nya proj
                await _projectScheduleRepository.RemoveAsync(createdScheduleWithId);
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project. Removed the created schedule.");

            }

            var projectServiceEntityToAdd = ProjectServiceFactory.CreateEntityFromNewProjectForm(form.ProjectService, createdProjectEntityWithId.Id);
            if (projectServiceEntityToAdd == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project service entity");
            
            var createdProjectServiceWithId = await _projectServiceRepository.AddAsync(projectServiceEntityToAdd);
            if (createdProjectServiceWithId == null)
            {
                // Ta bort mitt projekt OCH SEN mitt projektschema om det inte funkar att skapa projectservice
                await _projectRepository.RemoveAsync(createdProjectEntityWithId);
                await _projectScheduleRepository.RemoveAsync(createdScheduleWithId);
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project service. Removed the created project and schedule.");
            }

            var projectResult = ProjectFactory.CreateProjectFromEntity(createdProjectEntityWithId);
            return ResponseResult<Project?>.Created("Project was successfully created!", projectResult);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<Project?>.Error("Something went wrong when creating the project");
        }
    }

    public async Task<ResponseResult<Project?>> UpdateProjectAsync(ProjectUpdateForm updateForm)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == updateForm.CustomerId);
            var statusType = await _statusTypeRepository.GetAsync(s => s.Id == updateForm.StatusTypeId);
            var user = await _userRepository.GetAsync(u => u.Id == updateForm.UserId);
            var exists = await _projectRepository.ExistsAsync(c => c.Id == updateForm.Id);

            if (!exists)
                return ResponseResult<Project?>.NotFound("No project with that id exists.");
            if (customer == null)
                return ResponseResult<Project?>.NotFound("No customer with that id exists. Could not update project with the provided customer");
            if (statusType == null)
                return ResponseResult<Project?>.NotFound("No statusType with that id exists. Could not update project with that status");
            if (user == null)
                return ResponseResult<Project?>.BadRequest("No user with that id exists. Could not update project with invalid user.");

            var scheduleEntityToUpdate = ProjectScheduleFactory.CreateEntityFromUpdateFormWithId(updateForm.ProjectSchedule);

            if (scheduleEntityToUpdate == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying create schedule entity");

            var updatedScheduleEntity = await _projectScheduleRepository.UpdateAsync(scheduleEntityToUpdate);

            if (updatedScheduleEntity == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the date schedule. Project could not be created");

            var projectEntityWithUpdatedSchedule = ProjectFactory.CreateEntityFromUpdateForm(updateForm, updatedScheduleEntity);

            if (projectEntityWithUpdatedSchedule == null)
                return ResponseResult<Project?>.Error("Something went wrong when trying create project entity with updated schedule");

            var updatedProjectEntity = await _projectRepository.UpdateAsync(projectEntityWithUpdatedSchedule);

            if (updatedProjectEntity == null)
            {
                var oldScheduleEntity = ProjectScheduleFactory.CreateEntityFromUpdateFormWithId(updateForm.ProjectSchedule);
                if (oldScheduleEntity == null)
                    return ResponseResult<Project?>.Error("Something went wrong when trying to create the entity for the schedule");

                await _projectScheduleRepository.UpdateAsync(oldScheduleEntity);
                return ResponseResult<Project?>.Error("Something went wrong when trying to update the project. Schedule did not update.");
            }

            var projectResult = ProjectFactory.CreateProjectFromEntity(updatedProjectEntity);
            return ResponseResult<Project?>.Ok("Project was successfully updated!", projectResult);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<Project?>.Error("Something went wrong when updating the project");
        }
    }

    public async Task<ResponseResult> DeleteProjectByIdAsync(int id)
    {
        try
        {
            var projectEntityToDelete = await _projectRepository.GetAsync(x => x.Id == id);
            if (projectEntityToDelete == null)
                return ResponseResult.EntityNotFound($"The project with id: {id} could not be found.");

            // ta bort beroende entiteter av projectet innan projekt kan tas bort, sen projektschedule
            var isProjectServicesDeleted = await _projectServiceRepository.RemoveAllProjectServicesByProjectId(id);
            if (!isProjectServicesDeleted)
            {
                return ResponseResult.Failed("Could not delete project services connected to the project");
            }

            var result = await _projectRepository.RemoveAsync(projectEntityToDelete);
            if (!result)
                return ResponseResult.Failed("Something went wrong. Could not delete project.");

            var scheduleEntityToDelete = await _projectScheduleRepository.GetAsync(s => s.Id == projectEntityToDelete.ProjectScheduleId);
            if (scheduleEntityToDelete != null)
            {
                var scheduleResult = await _projectScheduleRepository.RemoveAsync(scheduleEntityToDelete!);
                if (!scheduleResult)
                    return ResponseResult.Failed("Could not delete project schedule connected to the project");

                return ResponseResult.NoContentSuccess();
            }

            return ResponseResult.Succeeded("Project was deleted but no project schedule was found and deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ListProject?>.Error($"Something went wrong when trying to delete the project with id: {id}");
        }
    }
}
