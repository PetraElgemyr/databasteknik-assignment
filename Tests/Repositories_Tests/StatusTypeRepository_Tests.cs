//using Data.Contexts;
//using Data.Interfaces;
//using Data.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Tests.SeedData;

//namespace Tests.Repositories_Tests;

//public class StatusTypeRepository_Tests
//{


//    [Fact]
//    public async Task AddAsync_ShouldAddStatus()
//    {
//        //Arrange
//        var context = DataContextSeeder.GetDataContext();
//        var statusTypeRepository = new StatusTypeRepository(context);

//        //Act
//        var result = await statusTypeRepository.AddAsync(TestData.StatusTypeEntities[0]);

//        //Assert
//        Assert.NotNull(result);
//        Assert.NotEqual(1, result!.Id);
//    }

//    [Fact]
//    public async Task GetAllAsync_ShouldReturnAllStatusTypes()
//    {
//        // Arrange
//        var context = DataContextSeeder.GetDataContext();
//        await DataContextSeeder.SeedAsync(context);

//        var statusTypeRepository = new StatusTypeRepository(context);


//        // Act
//        var result = await statusTypeRepository.GetAllAsync();

//        // Assert
//        Assert.Equal(TestData.StatusTypeEntities.Length, result.Count());
//    }
//}                 

