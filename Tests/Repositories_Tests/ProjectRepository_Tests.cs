using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectRepository_Tests
{
    //private DataContext GetDataContext()
    //{
    //    var options = new DbContextOptionsBuilder<DataContext>()
    //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
    //        .Options;

    //    var context = new DataContext(options);
    //    context.Database.EnsureCreated();
    //    return context;
    //}


    //[Fact]
    //public async Task CreateProjectAsyncc_ShouldCreateProject()
    //{
    //    // Arrange
    //    var context = GetDataContext();
    //    context.Projects.AddRange(TestData.ProjectEntities);
    //    context.Users.AddRange(TestData.UserEntities);

    //    context.SaveChanges();

    //    IUserRepository repository = new UserRepository(context);


    //    // Act
    //    var result = await repository.GetAllAsync();

    //    // Assert
    //    Assert.Equal(result.Count(), TestData.UserEntities.Length);
    //}

}

