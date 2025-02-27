using Business.Models;
using Business.Models.Roles;
using Business.Models.Users;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class UserFactory
{
    public static UserEntity? CreateUserEntityFromRegistrationForm(UserRegistrationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var userEntity = new UserEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                RoleId = form.RoleId
            };
            return userEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static UserEntity? CreateUserEntityFromUser(User user)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(user);

            var userEntity = new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId
            };
            return userEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }

    }

    public static ListUser? CreateListUserFromEntity(UserEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);
            var user = new ListUser
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Role = new UserRole { RoleName = entity.Role.RoleName }
            };
            return user;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }


    }

    public static User? CreateUserFromEntity(UserEntity entity)
    {

        try
        {
            ArgumentNullException.ThrowIfNull(entity);
            var user = new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                RoleId = entity.RoleId
            };
            return user;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }


    }
}

