using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
    public async Task<IEnumerable<UserEntity>> GetAllListUsersAsync()
    {
        try
        {
            var entities = await _context.Users
                .Include(x => x.Role)
                .Select(x => new UserEntity
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Role = new RoleEntity
                    {
                        RoleName = x.Role.RoleName
                    },
                }).ToListAsync();

            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }


    public async Task<IEnumerable<UserEntity>> GetAllByRoleNameAsync(string roleName)
    {
        try
        {
            var entities = await _context.Users
                     .Include(x => x.Role)
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
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }

    public override async Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {

        try
        {
            var entity = await _context.Users
                .Include(x => x.Role)
                .Select(x => new UserEntity
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Role = new RoleEntity
                    {
                        Id = x.Role.Id,
                        RoleName = x.Role.RoleName
                    },
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

