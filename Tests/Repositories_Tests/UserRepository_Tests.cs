using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class UserRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldReturnAddedUser()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);

        await context.SaveChangesAsync();

        var userToAdd = new UserEntity
        {
            FirstName = "Bertil",
            LastName = "Bertsson",
            Email = "bert@domain.com",
            PhoneNumber = "",
            RoleId = TestData.RoleEntities[0].Id
        };

        var userRepository = new UserRepository(context);
        var result = await userRepository.AddAsync(userToAdd);

        Assert.NotNull(result);
        Assert.Equal(userToAdd.Id, result.Id);

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        var context = new DataContextSeeder().GetDataContext();

        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
        var userRepository = new UserRepository(context);

        var result = await userRepository.GetAllAsync();
        Assert.Equal(TestData.UserEntities.Length, result.Count());

    }

    [Fact]
    public async Task GetAllListUsersAsync_ShouldReturnAllListUsers()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
        var userRepository = new UserRepository(context);
        var result = await userRepository.GetAllListUsersAsync();

        Assert.Equal(TestData.UserEntities.Length, result.Count());
    }
    [Fact]
    public async Task GetAllByRoleNameAsync_ShouldReturnUsersByRoleName()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
        var userRepository = new UserRepository(context);
        var result = await userRepository.GetAllByRoleNameAsync("Projektledare");

        Assert.Equal(2, result.Count());

    }


    [Fact]
    public async Task GetAsync_ShouldReturnOneUser()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
        var userRepository = new UserRepository(context);
        var result = await userRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);

    }


    [Fact]
    public async Task ExistsAsync_ShouldReturnExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
        var userRepository = new UserRepository(context);

        var userToAdd = new UserEntity
        {
            Id = 4,
            FirstName = "Bertil",
            LastName = "Bertsson",
            Email = "bert@domain.com",
            PhoneNumber = "",
            RoleId = TestData.RoleEntities[0].Id
        };
        var result = await userRepository.ExistsAsync(u => u.Id == 4);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnUser()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var userRepository = new UserRepository(context);

        var userToUpdate = new UserEntity
        {
            Id = 1,
            FirstName = "Harry",
            LastName = "Harrymansson",
            Email = "h@domain.com",
            PhoneNumber = "",
            RoleId = TestData.RoleEntities[1].Id
        };

        var result = await userRepository.UpdateAsync(userToUpdate);

        Assert.NotNull(result);
        Assert.Equal(userToUpdate.FirstName, result.FirstName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveUserAndReturnTrue()
    {

        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var userRepository = new UserRepository(context);
        var userToDelete = await userRepository.GetAsync(x => x.Id == 1);

        var result = await userRepository.RemoveAsync(userToDelete!);

        Assert.True(result);
    }
}

