using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class CustomerTypeRepository_Tests
{

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCustomers()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerTypeRepository = new CustomerTypeRepository(context);

        var result = await customerTypeRepository.GetAllAsync();
        Assert.Equal(TestData.CustomerTypeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnOneCustomerType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerTypeRepository = new CustomerTypeRepository(context);
        var result = await customerTypeRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedCustomerType()
    {
        var context = new DataContextSeeder().GetDataContext();

        var customerTypeToAdd = new CustomerTypeEntity {  CustomerTypeName = "Företag" };

        var customerTypeRepository = new CustomerTypeRepository(context);
        var result = await customerTypeRepository.AddAsync(customerTypeToAdd);

        Assert.NotNull(result);
        Assert.Equal("Företag", result.CustomerTypeName);

    }


    [Fact]
    public async Task ExistsAsync_ShouldReturnCustomerTypeExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerTypeRepository = new CustomerTypeRepository(context);

        var typeToAdd = new CustomerTypeEntity { Id = 1, CustomerTypeName = "Företag" };
        var result = await customerTypeRepository.ExistsAsync(ct => ct.Id == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnCustomerType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var customerTypeRepository = new CustomerTypeRepository(context);
        var customerTypeToUpdate = new CustomerTypeEntity {Id=2, CustomerTypeName = "Privat" };


        var result = await customerTypeRepository.UpdateAsync(customerTypeToUpdate);

        Assert.NotNull(result);
        Assert.Equal(customerTypeToUpdate.CustomerTypeName, result.CustomerTypeName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveCustomerTypeAndReturnTrue()
    {

        var context = new DataContextSeeder().GetDataContext();
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var customerTypeRepository = new CustomerTypeRepository(context);
        var typeToDelete = await customerTypeRepository.GetAsync(x => x.Id == 1);

        var result = await customerTypeRepository.RemoveAsync(typeToDelete!);

        Assert.True(result);
    }

}

