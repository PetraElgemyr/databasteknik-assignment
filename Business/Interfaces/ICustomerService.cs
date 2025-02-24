using Business.Models;
using Business.Models.Customers;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<ResponseResult<Customer?>> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<ResponseResult> DeleteCustomerByIdAsync(int id);
    Task<ResponseResult> DeleteOneCustomerAsync(Customer form);
    Task<ResponseResult<IEnumerable<Customer>>> GetAllCustomersAsync();
    Task<ResponseResult<Customer>> GetOneCustomerByIdAsync(int id);
    Task<ResponseResult<Customer>> UpdateCustomerAsync(Customer customer);
}