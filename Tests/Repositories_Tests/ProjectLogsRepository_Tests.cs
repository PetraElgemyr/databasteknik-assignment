using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectLogsRepository_Tests
{


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectLogs()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectLogs.AddRange(TestData.ProjectLogs);
        await context.SaveChangesAsync();

        var projectLogRepository = new ProjectLogRepository(context);

        var result = await projectLogRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.ProjectLogs.Length, result.Count());
    }

}

