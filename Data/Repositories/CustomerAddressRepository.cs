using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;


public class CustomerAddressRepository(DataContext context) : BaseRepository<CustomerAddressEntity>(context), ICustomerAddressRepository
{

    public override async Task<CustomerAddressEntity?> GetAsync(Expression<Func<CustomerAddressEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.CustomerAddresses
                .Include(x => x.PostalCode)
                .Include(x => x.CustomerContact)
                .Select(x => new CustomerAddressEntity
                {
                    Id = x.Id,
                    StreetName = x.StreetName,
                    StreetNumber = x.StreetNumber,
                    PostalCode = new PostalCodeEntity
                    {
                        PostalCode = x.PostalCode.PostalCode,
                        City = x.PostalCode.City
                    },
                    CustomerContact = new CustomerContactEntity
                    {
                        Id = x.CustomerContact.Id,
                        FirstName = x.CustomerContact.FirstName,
                        LastName = x.CustomerContact.LastName,
                        Email = x.CustomerContact.Email,
                        PhoneNumber = x.CustomerContact.PhoneNumber,
                        Customer = new CustomerEntity
                        {
                            Id = x.CustomerContact.Customer.Id,
                            CustomerName = x.CustomerContact.Customer.CustomerName
                        }
                    }
                })
                .FirstOrDefaultAsync(predicate);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
