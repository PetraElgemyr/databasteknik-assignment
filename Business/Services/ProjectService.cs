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

public class ProjectService(IProjectRepository projectRepository, IProjectScheduleRepository projectScheduleRepository, ICustomerRepository customerRepository, IStatusTypeRepository statusTypeRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IProjectScheduleRepository _projectScheduleRepository = projectScheduleRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task<ResponseResult<IEnumerable<ListProject>?>> GetAllProjectsAsync()
    {
        try
        {
            var entities = await _projectRepository.GetAllAsync();
            var listProjects = entities.Select(ProjectFactory.CreateListProjectFromEntity);

            return ResponseResult<IEnumerable<ListProject>?>.Ok("All projects fetched successfully!", listProjects);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ListProject>?>.Error($"Something went wrong when trying to fetch all projects. {ex.Message}");
        }
    }
    public async Task<ResponseResult<ProjectWithDetails?>> GetOneProjectByIdAsync(int projectId)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == projectId);

            if (projectEntity == null)
            {
                return ResponseResult<ProjectWithDetails?>.NotFound($"No project with id {projectId} could be found.");
            }

            var projectWithDetails = ProjectFactory.CreateProjectWithDetailsFromEntity(projectEntity);
            return ResponseResult<ProjectWithDetails?>.Ok("Project with details successfully fetched!", projectWithDetails);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ProjectWithDetails?>.Error($"Something went wrong when fetching project with id {projectId}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ListProject>?>> GetAllProjectsByCustomerIdAsync(int customerId)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return ResponseResult<IEnumerable<ListProject>?>.NotFound($"No customer with id: {customerId} exists.");
            }
            var entities = await _projectRepository.GetAllProjectByCustomerIdAsync(customerId);
            var listProjectsForCustomer = entities!.Select(ProjectFactory.CreateListProjectFromEntity);


            return ResponseResult<IEnumerable<ListProject>?>.Ok($"All projects for customer with id: {customerId} successfully fetched.", listProjectsForCustomer);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ListProject>?>.Error($"Something went wrong when trying to fetch the projects for the customer with id: {customerId}. {ex.Message}");
        }
    }


    public async Task<ResponseResult<Project?>> CreateNewProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == form.CustomerId);
            var statusType = await _statusTypeRepository.GetAsync(s => s.Id == form.StatusTypeId);

            if (customer == null)
            {
                return ResponseResult<Project?>.NotFound("No customer with that id exists. Could not create project with the provided customer");
            }
            if (statusType == null)
            {
                return ResponseResult<Project?>.NotFound("No statusType with that id exists. Could not create project with that status");
            }

            var projectEntity = ProjectFactory.CreateEntityFromRegistrationForm(form);
            var createdProjectEntityWithId = await _projectRepository.AddAsync(projectEntity);

            if (createdProjectEntityWithId == null)
            {
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project");
            }

            var schedule = new ProjectSchedule
            {
                // måste tillsätta mitt nya projektid
                ProjectId = createdProjectEntityWithId.Id,
                StartDate = form.ProjectSchedule.StartDate,
                EndDate = form.ProjectSchedule.EndDate,
            };
            var projectScheduleEntity = ProjectScheduleFactory.CreateEntityFromForm(schedule);
            var createdScheduleWithId = await _projectScheduleRepository.AddAsync(projectScheduleEntity);

            if (createdScheduleWithId == null)
            {
                // Om schemat inte kan skapas, radera mitt skapade projekt o skicka felmeddelande!
                await _projectRepository.RemoveAsync(createdProjectEntityWithId);
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project schedule. Project could not be created");
            }

            var projectResult = ProjectFactory.CreateProjectFromEntity(createdProjectEntityWithId);
            var scheduleResult = ProjectScheduleFactory.CreateScheduleFromEntity(createdScheduleWithId);
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
            var exists = await _projectRepository.ExistsAsync(c => c.Id == updateForm.Id);

            if (!exists)
            {
                return ResponseResult<Project?>.NotFound("No project with that id exists.");
            }
            if (customer == null)
            {
                return ResponseResult<Project?>.NotFound("No customer with that id exists. Could not create project with the provided customer");
            }
            if (statusType == null)
            {
                return ResponseResult<Project?>.NotFound("No statusType with that id exists. Could not create project with that status");
            }
           
            ProjectEntity projectEntity = ProjectFactory.CreateEntityFromUpdateForm(updateForm);
            var updateResult = await _projectRepository.UpdateAsync(projectEntity);
            if (updateResult == null)
            {
                return ResponseResult<Project?>.Error("Something went wrong when updating the project");
            }
          
            var updatedProject = ProjectFactory.CreateProjectFromEntity(projectEntity);

            //var oldSchedule = await _projectScheduleRepository.GetAsync(s => s.ProjectId == updateForm.Id);
            //if(oldSchedule == null)
            //{
            //    return ResponseResult<Project?>.Error("No date schedule found for the project.");
            //}

            //var updatedSchedule = new ProjectSchedule
            //{
            //    Id = oldSchedule.Id,
            //    ProjectId = updateForm.Id,
            //    StartDate = updateForm.ProjectSchedule.StartDate,
            //    EndDate = updateForm.ProjectSchedule.EndDate,
            //};

            //var updatedProjectScheduleEntity  = ProjectScheduleFactory.CreateEntityFromForm(updatedSchedule);
            //var updatedScheduleEntity = await _projectScheduleRepository.UpdateAsync(updatedProjectScheduleEntity);
            //if (updatedScheduleEntity == null)
            //{
            //    return ResponseResult<Project?>.Error("Could not update the dates for project");
            //}
           
            //var updatedProject = ProjectFactory.CreateProjectFromEntity(updateProjectEntity);
            return ResponseResult<Project?>.Ok("Project was successfully updated", updatedProject);

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
            {
                return ResponseResult.EntityNotFound($"The project with id: {id} could not be found.");
            }

            var result = await _projectRepository.RemoveAsync(projectEntityToDelete);
            if (!result)
            {
                return ResponseResult.Failed("Something went wrong. Could not delete project.");
            }

            // TODO kolla med Hans om man måste radera alla projectschedules med det projectId:t också
            return ResponseResult.NoContentSuccess();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ListProject?>.Error($"Something went wrong when trying to delete the project with id: {id}");
        }
    }
}
