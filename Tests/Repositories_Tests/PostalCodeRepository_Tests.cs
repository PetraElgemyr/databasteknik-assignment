using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class PostalCodeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShoudReturnAllPostalCodes()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.PostalCodes.AddRange(TestData.PostalCodeEntities);
        await context.SaveChangesAsync();

        var postalCodeRepository = new PostalCodeRepository(context);
        var result = await postalCodeRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.PostalCodeEntities.Length, result.Count());
    }

}

