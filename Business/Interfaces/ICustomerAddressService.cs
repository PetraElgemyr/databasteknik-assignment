using Business.Models;
using Business.Models.CusomerAddresses;

namespace Business.Interfaces;

public interface ICustomerAddressService
{
    Task<ResponseResult<IEnumerable<CustomerAddress>>> GetAllCustomerAddressesAsync();
    Task<ResponseResult<CustomerAddressWithDetails?>> GetOneCustomerAddressWithDetailsByIdAsync(int id);
}