using Business.Interfaces;
using Business.Models.Projects;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var result = await _projectService.GetAllProjectsAsync();
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message)
        };
    }

    [HttpGet]
    [Route("{projectId}")]
    public async Task<IActionResult> GetProjectById(int projectId)
    {
        var result = await _projectService.GetOneProjectByIdAsync(projectId);
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message)
        };
    }

    [HttpGet]
    [Route("customer/{id}")]
    public async Task<IActionResult> GetProjectsByCustomerId(int id)
    {
        var result = await _projectService.GetAllProjectsByCustomerIdAsync(id);
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message)
        };
    }


    [HttpPost]
    public async Task<IActionResult> CreateNewProject(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid project provided.");
        }

        var result = await _projectService.CreateNewProjectAsync(form);
        
        return result.StatusCode switch
        {
            201 => Created("Project was successfully created!",result.Result),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject(ProjectUpdateForm updateForm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid project provided.");
        }


        var result = await _projectService.UpdateProjectAsync(updateForm);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var result = await _projectService.DeleteProjectByIdAsync(id);
        return result.StatusCode switch
        {
            204 => NoContent(),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }
}
