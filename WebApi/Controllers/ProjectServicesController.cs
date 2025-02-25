using Business.Models.ProjectServices;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectServicesController(IProjectServiceService projectServiceService) : ControllerBase
{
    private readonly IProjectServiceService _projectServiceService = projectServiceService;

    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectServicesByProjectId(int projectId)
    {
        var result = await _projectServiceService.GetProjectServicesByProjectIdAsync(projectId);
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message),
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateServiceAndProjectService(ProjectServiceRegistrationForm form)
    {
        if (!ModelState.IsValid)
        { 
            return BadRequest("Invalid model for project service provided!"); 
        }

        var result = await _projectServiceService.CreateNewProjectServiceAsync(form);
        return result.StatusCode switch
        {
            201 => Created("", result.Result),
            400 => BadRequest(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpDelete("{projectId}-{serviceId}")]
    public async Task<IActionResult> RemoveProjectServiceById(int projectId,int serviceId)
    {
        var result = await _projectServiceService.DeleteProjectServiceByIdAsync(projectId, serviceId);


        return result.StatusCode switch
        {
            204 => NoContent(),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }
}
