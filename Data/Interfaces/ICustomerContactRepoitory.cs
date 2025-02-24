using Data.Entities;

namespace Data.Interfaces;

public interface ICustomerContactRepoitory : IBaseRepository<CustomerContactEntity>
{
    Task<IEnumerable<CustomerContactEntity>> GetAllCustomerContactsByCustomerId(int id);
}