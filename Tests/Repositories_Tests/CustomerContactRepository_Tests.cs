using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class CustomerContactRepository_Tests
{

    [Fact]
    public async Task GetAllCustomerContactsByCustomerId_ShouldReturnAllCustomerContactsByCustomer()
    {
        var context = new DataContextSeeder().GetDataContext();

        context.CustomerContacts.AddRange(TestData.CustomerContactEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        await context.SaveChangesAsync();

        var customerContactRepoitory = new CustomerContactRepoitory(context);
        var result = await customerContactRepoitory.GetAllCustomerContactsByCustomerId(2);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCustomerContacts()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerContacts.AddRange(TestData.CustomerContactEntities);
        await context.SaveChangesAsync();

        var customerContactRepoitory = new CustomerContactRepoitory(context);
        var result = await customerContactRepoitory.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.CustomerContactEntities.Length, result.Count());

    }

}

