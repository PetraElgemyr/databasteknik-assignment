using Business.Models;
using Business.Models.Roles;
using Business.Models.Users;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static UserEntity CreateUserEntityFromRegistrationForm(UserRegistrationForm form)
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

    public static UserEntity CreateUserEntityFromUser(User user)
    {
        return new UserEntity
        {
            Id = user.Id,   
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            RoleId = user.RoleId
        };
    }

    public static ListUser CreateListUserFromEntity(UserEntity entity)
    {
        return new ListUser
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = new UserRole {  RoleName = entity.Role.RoleName }
        };
    }

    public static User CreateUserFromEntity(UserEntity entity)
    {
        return new User
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            RoleId = entity.RoleId
        };
    }
}

