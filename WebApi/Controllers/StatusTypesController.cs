using Business.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTypesController(IStatusTypeService statusTypeService) : ControllerBase
{
    private readonly IStatusTypeService _statusTypeService = statusTypeService;

    [HttpGet]
    public async Task<IActionResult> GetAllStatuses()
    {
        var result = await _statusTypeService.GetAllListStatusesAsync();
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message),
        };
    }
}



