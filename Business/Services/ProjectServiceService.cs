using Business.Factories;
using Business.Models;
using Business.Models.ProjectServices;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectServiceService(IProjectServiceRepository projectServiceRepository, IServiceRepository serviceRepository, IProjectRepository projectRepository) : IProjectServiceService
{
    private readonly IProjectServiceRepository _projectServiceRepository = projectServiceRepository;
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ResponseResult<IEnumerable<ProjectServiceWithDetails>>> GetProjectServicesByProjectIdAsync(int projectId)
    {
        try
        {
            var entities = await _projectServiceRepository.GetAllProjectServicesByProjectIdAsync(projectId);
            if (entities == null)
                return ResponseResult<IEnumerable<ProjectServiceWithDetails>>.Error("Something went wrong when fetching the project services");

            var projectServices = entities.Select(ProjectServiceFactory.CreateProjectServiceFromEntity);
            return ResponseResult<IEnumerable<ProjectServiceWithDetails>>.Ok("All services for this project", projectServices);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ProjectServiceWithDetails>>.Error("Something went wrong when fetching the project services");
        }
    }

    public async Task<ResponseResult<ProjectServiceWithDetails?>> CreateNewProjectServiceAsync(ProjectServiceRegistrationForm form)
    {
        try
        {
            var existingProject = await _projectRepository.GetAsync(p => p.Id == form.ProjectId);
            var foundService = await _serviceRepository.GetAsync(s => s.Id  == form.ServiceId);

            if (existingProject == null)
                return ResponseResult<ProjectServiceWithDetails?>.BadRequest($"Invalid project id provided. There is no project with id: {form.ProjectId}");
            if (foundService == null)
                return ResponseResult<ProjectServiceWithDetails?>.BadRequest("Invalid service id provided. No service with that id exists.");

            var projectServiceEntityToAdd = ProjectServiceFactory.CreateProjectServiceEntityFromRegForm(form);
            var createdProjectServiceEntity = await _projectServiceRepository.AddAsync(projectServiceEntityToAdd);
            if (createdProjectServiceEntity == null)
            {
                return ResponseResult<ProjectServiceWithDetails?>.Error("Something went wrong when creating the project service. The service is removed.");
            }
            // kanske måste ha get proj serv här för att få med service
            var addedProjectServiceWithDetails = ProjectServiceFactory.CreateProjectServiceFromEntity(createdProjectServiceEntity);
            return ResponseResult<ProjectServiceWithDetails?>.Created("Project service was successfully created!", addedProjectServiceWithDetails);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ProjectServiceWithDetails?>.Error("Something went wrong when creating the project service");
        }
    }

    public async Task<ResponseResult> DeleteProjectServiceByIdAsync(int projectId, int serviceId)
    {
        try
        {
          var succeeded =  await _projectServiceRepository.RemoveAsyncByFKKeys(projectId, serviceId);
            if (succeeded)
                return ResponseResult.NoContentSuccess();

            return ResponseResult.Failed("The project service could not be deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed("Something went wrong when removing the project service.");
        }
    }

}
