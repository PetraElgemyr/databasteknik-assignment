using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class CustomerRepository_Tests
{



    [Fact]
    public async Task GetAllAsync_ShoudReturnAllCustomers()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);
        var result = await customerRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.CustomerEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnFoundCustomer()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);
        var customer = await customerRepository.GetAsync(x => x.Id == TestData.CustomerEntities[0].Id);

        Assert.NotNull(customer);
        Assert.Equal(TestData.CustomerEntities[0].Id, customer.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldAddAndReturnCustomer()
    {
        var context = new DataContextSeeder().GetDataContext();

        var customer = new CustomerEntity { CustomerName = "Arvid Vigren", CustomerTypeId = 1 };
        var customerRepository = new CustomerRepository(context);
        var result = await customerRepository.AddAsync(customer);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCustomerAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var customerToUpdate = new CustomerEntity { Id = 1, CustomerName = "Arnold Arreman", CustomerTypeId = 1 };
        var customerRepository = new CustomerRepository(context);
        var result = await customerRepository.UpdateAsync(customerToUpdate);

        Assert.NotNull(result);
        Assert.Equal(customerToUpdate.CustomerName, result.CustomerName);

    }

    [Fact]
    public async Task RemoveAsync_ShouldDeleteCustomerAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var customerRepository = new CustomerRepository(context);
        var result = await customerRepository.RemoveAsync(TestData.CustomerEntities[0]);

        Assert.True(result);

    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrueIfCustomerExists()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);
        var result = await customerRepository.ExistsAsync(x => x.Id == 1);

        Assert.True(result);

    }

}

