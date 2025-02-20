using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
    //public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    //{
    //    var entities = await _context.Users.ToListAsync();
    //    return entities;
    //}

    public async Task<IEnumerable<UserEntity>> GetAllListUsersAsync()
    {
        // För att visa users i en överskådlig lista för admin (get alla users och visa basic info)
        // Hämta firstname, lastname, customername, role
        // Klickbar sen och då hämta en user med all info
        var entities = await _context.Users
            .Include(x => x.Role)
            .Include(x => x.Customer)
            .Select(x => new UserEntity
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = new RoleEntity
                {
                    RoleName = x.Role.RoleName
                },
                Customer = new CustomerEntity
                {
                    CustomerName = x.Customer.CustomerName,
                }
            }).ToListAsync();

        return entities;
    }


    // Hämta en users namn och id baserat på roll
    public async Task<IEnumerable<UserEntity>> GetAllByRoleNameAsync(string roleName)
    {
        var entities = await _context.Users
           .Include(x => x.Role)
           .Include(x => x.Customer)
           .Where(x => x.Role.RoleName == roleName)
           .Select(x => new UserEntity
           {
               Id = x.Id,
               FirstName = x.FirstName,
               LastName = x.LastName
           })
           .ToListAsync();

        return entities;
    }

    // hämtar en user utan phonenumber, baserat på valfri predicate
    public override async Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var entity = await _context.Users
            .Include(x => x.Role)
            .Include(x => x.Customer)
            .Select(x => new UserEntity
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = new RoleEntity
                {
                    RoleName = x.Role.RoleName
                },
                Customer = new CustomerEntity
                {
                    CustomerName = x.Customer.CustomerName,
                }
            })
            .FirstOrDefaultAsync(predicate);

        return entity;
    }
}

