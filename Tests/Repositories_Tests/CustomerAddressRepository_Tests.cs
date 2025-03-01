using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class CustomerAddressRepository_Tests
{
    //postal, customer contact, customer
    [Fact]
    public async Task GetAsync_ShouldReturnCustomerAddress()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
        context.CustomerContacts.AddRange(TestData.CustomerContactEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.PostalCodes.AddRange(TestData.PostalCodeEntities);
        await context.SaveChangesAsync();

        var customerAddressRepository = new CustomerAddressRepository(context);
        var result = await customerAddressRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
        Assert.Equal("Storgatan", result.StreetName);
    }


    [Fact]
    public async Task GetAll_ShouldReturnCustomerAddresses()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
        await context.SaveChangesAsync();

        var customerAddressRepository = new CustomerAddressRepository(context);
        var result = await customerAddressRepository.GetAllAsync();
        Assert.NotNull(result);
        Assert.Equal(TestData.CustomerAddressEntities.Length, result.Count());
    }
}

