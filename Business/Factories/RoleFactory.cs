using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static Role Create(RoleEntity entity)
    {
        return new Role
        {
            Id = entity.Id,
            RoleName = entity.RoleName
        };
    }
}
