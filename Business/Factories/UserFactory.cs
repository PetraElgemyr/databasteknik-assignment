using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static UserEntity CreateUserEntity(UserRegistrationForm form)
    {
        return new UserEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            RoleId = form.RoleId
        };
    }

    public static UserEntity CreateUserEntityFromUpdateForm(UserUpdateForm form)
    {
        return new UserEntity
        {
            Id = form.Id,   
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            RoleId = form.RoleId
        };
    }

    public static ListUser CreateListUser(UserEntity entity)
    {
        return new ListUser
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = new UserRole {  RoleName = entity.Role.RoleName }
        };
    }
}

