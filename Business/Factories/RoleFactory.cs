using Business.Models.Roles;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static Role? Create(RoleEntity entity) => entity == null ? null : new Role
    {
        Id = entity.Id,
        RoleName = entity.RoleName
    };

}
