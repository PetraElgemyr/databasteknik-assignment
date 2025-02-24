using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Customers
                .Include(x => x.CustomerType)
                .Select(x => new CustomerEntity
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    CustomerType = new CustomerTypeEntity
                    {
                        Id = x.CustomerType.Id,
                        CustomerTypeName = x.CustomerType.CustomerTypeName
                    },
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
    public override async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Customers
                .Include(x => x.CustomerType)
                .Select(x => new CustomerEntity
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    CustomerType = new CustomerTypeEntity
                    {
                        Id = x.CustomerType.Id,
                        CustomerTypeName = x.CustomerType.CustomerTypeName
                    }
                })
                .FirstOrDefaultAsync(expression);

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
