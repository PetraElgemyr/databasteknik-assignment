using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Projects;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IProjectScheduleRepository projectScheduleRepository, ICustomerService customerService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IProjectScheduleRepository _projectScheduleRepository = projectScheduleRepository;
    private readonly ICustomerService _customerService = customerService;
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
    public async Task<ResponseResult<Project?>> GetOneProjectByIdAsync(int projectId)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == projectId);

            if (projectEntity == null)
            {
                return ResponseResult<Project?>.NotFound($"No project with id {projectId} could be found.");
            }

            var project = ProjectFactory.CreateProjectFromEntity(projectEntity);
            return ResponseResult<Project?>.Ok("Project with details successfully fetched!", project);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<Project?>.Error($"Something went wrong when fetching project with id {projectId}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ListProject>?>> GetAllProjectsByCustomerIdAsync(int customerId)
    {
        try
        {
            var customer = _customerService.GetOneCustomerByIdAsync(customerId);

            if (customer == null)
            {
                return ResponseResult<IEnumerable<ListProject>?>.NotFound($"No customer with id: {customerId} exists.");
            }

            var entities = await _projectRepository.GetAllProjectByCustomerId(customerId);
            var listProjectsForCustomer = entities.Select(ProjectFactory.CreateListProjectFromEntity);


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
            var projectEntity = ProjectFactory.CreateEntityFromRegistrationForm(form);
            var createdProjectEntityWithId = await _projectRepository.AddAsync(projectEntity);

            if (createdProjectEntityWithId == null)
            {
                return ResponseResult<Project?>.Error("Something went wrong when trying to create the project");
            }

            var schedule = form.ProjectSchedule;
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
            var oldEntity = await _projectRepository.GetAsync(x => x.Id == updateForm.Id);
            if (oldEntity == null)
            {
                return ResponseResult<Project?>.NotFound("No project with that id exists.");
            }

            var projectEntity = ProjectFactory.CreateEntityFromUpdateForm(updateForm);
            if (projectEntity == null)
            {
                return ResponseResult<Project?>.BadRequest("Invalid project to update.");
            }

            var updatedEntity = await _projectRepository.UpdateAsync(projectEntity);

            if (updatedEntity == null)
            {
                return ResponseResult<Project?>.Error("Something went wrong when updating the project");
            }
            var updatedProject = ProjectFactory.CreateProjectFromEntity(updatedEntity);

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
