using Business.Models;

namespace Business.Interfaces;

public interface ICustomerTypeService
{
    Task<ResponseResult<IEnumerable<CustomerType>>> GetAllCustomerTypesAsync();
}