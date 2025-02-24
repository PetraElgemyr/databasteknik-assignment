using Business.Models;
using Business.Models.CustomerContacts;

namespace Business.Interfaces;

public interface ICustomerContactService
{
    Task<ResponseResult<IEnumerable<CustomerContact>>> GetAllCustomerContactsByCustomerIdAsync(int customerId);
}