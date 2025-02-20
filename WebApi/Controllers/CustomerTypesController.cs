using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypesController(ICustomerTypeService customerTypeService) : ControllerBase
    {

        private readonly ICustomerTypeService _customerTypeService = customerTypeService;

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerTypes()
        {
            var types = await _customerTypeService.GetAllCustomerTypesAsync();
            return Ok(types);
        }
    }
}
