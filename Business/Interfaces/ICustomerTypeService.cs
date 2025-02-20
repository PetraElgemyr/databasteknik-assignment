using Business.Models;

namespace Business.Interfaces;

public interface ICustomerTypeService
{
    Task<IEnumerable<CustomerType>> GetAllCustomerTypesAsync();
}