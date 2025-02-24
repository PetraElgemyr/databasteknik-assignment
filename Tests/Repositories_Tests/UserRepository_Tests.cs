using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class UserRepository_Tests
{


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        var context = DataContextSeeder.GetDataContext();

        context.Roles.AddRange(TestData.RoleEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();

        var userRepository = new UserRepository(context);

        var result = await userRepository.GetAllAsync();
        Assert.Equal(TestData.UserEntities.Length, result.Count());
    }



    //[Fact]
    //public async Task GetUsersAsync_ShouldReturnAllUsers()
    //{
    //    // Arrange
    //    var context = GetDataContext();
    //    context.Roles.AddRange(TestData.RoleEntities);
    //    await context.SaveChangesAsync();

    //    context.Users.AddRange(TestData.UserEntities);

    //    await context.SaveChangesAsync();

    //    IUserRepository repository = new UserRepository(context);


    //    // Act
    //    var result = await repository.GetAllAsync();

    //    // Assert
    //    Assert.Equal(TestData.UserEntities.Length, result.Count());
    //    //Assert.Equal(result.Count(), TestData.UserEntities.Length);
    //}
}

