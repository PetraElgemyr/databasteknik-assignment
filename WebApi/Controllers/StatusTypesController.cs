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
        var statuses = await _statusTypeService.GetAllListStatusesAsync();
        return Ok(statuses);
    }
}



