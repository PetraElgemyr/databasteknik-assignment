using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController(IServiceService serviceService) : ControllerBase
{

    private readonly IServiceService _serviceService = serviceService;

    [HttpGet]
    public async Task<IActionResult> GetAllServices()
    {
        var result = await _serviceService.GetAllServicesAsync();
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message),
        };
    }

    [HttpGet("{serviceType}")]
    public async Task<IActionResult> GetAllServicesByServiceType(string serviceType)
    {
      var result =  await _serviceService.GetAllServicesByServiceTypeAsync(serviceType);
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message),
        };
    }
}
