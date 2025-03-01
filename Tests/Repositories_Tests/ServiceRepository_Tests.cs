using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ServiceRepository_Tests
{


    [Fact]
   public async Task GetAllServicesByServiceType_ShouldReturnServicesByType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);

        var result = await serviceRepository.GetAllServicesByServiceType("Konsult");

        Assert.Equal(2, result.Count());

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllServices()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);

        var result = await serviceRepository.GetAllAsync();
        Assert.Equal(TestData.StatusTypeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnOneService()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);
        var result = await serviceRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedStatusType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ChangeTracker.Clear();

        var serviceToAdd = new ServiceEntity {  ServiceTypeName = "Konsult", ServiceName = "Projektledning", HourlyCost = 1900 };

        var serviceRepository = new ServiceRepository(context);
        var result = await serviceRepository.AddAsync(serviceToAdd);

        Assert.NotNull(result);
        Assert.Equal("Projektledning", result.ServiceName);
    }


    [Fact]
    public async Task ExistsAsync_ShouldReturnServiceExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);

        var result = await serviceRepository.ExistsAsync(st => st.Id == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnService()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();
        var serviceRepository = new ServiceRepository(context);

        var serviceToUpdate = new ServiceEntity { Id = 1, ServiceTypeName = "Konsult", ServiceName = "Projektledning", HourlyCost = 1900 };

        var result = await serviceRepository.UpdateAsync(serviceToUpdate);

        Assert.NotNull(result);
        Assert.Equal(serviceToUpdate.ServiceTypeName, result.ServiceTypeName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveServiceAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();


        context.ChangeTracker.Clear();

        var serviceRepository = new ServiceRepository(context);
        var serviceToDelete = await serviceRepository.GetAsync(x => x.Id == 1);

        var result = await serviceRepository.RemoveAsync(serviceToDelete!);

        Assert.True(result);
    }

}

