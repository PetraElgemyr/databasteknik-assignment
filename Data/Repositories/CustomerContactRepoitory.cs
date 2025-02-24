using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace Data.Repositories;

public class CustomerContactRepoitory(DataContext context) : BaseRepository<CustomerContactEntity>(context), ICustomerContactRepoitory
{
    public async Task<IEnumerable<CustomerContactEntity>> GetAllCustomerContactsByCustomerId(int id)
    {
        try
        {
            var entities = await _context.CustomerContacts
                .Include(x => x.Customer)
                .Include(x => x.Customer.CustomerType)
                .Where(x => x.CustomerId == id)
                .Select(x => new CustomerContactEntity
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Customer = new CustomerEntity
                    {
                        Id = x.Customer.Id,
                        CustomerName = x.Customer.CustomerName,
                    }
                })
                .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
