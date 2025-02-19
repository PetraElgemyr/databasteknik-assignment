using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Business.Services;

public class UserService(IUserRepository userRepository, IMemoryCache cache) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMemoryCache _cache = cache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

    public async Task<IEnumerable<ProjectManager>> GetAllProjectManagersAsync()
    {
        //var entities = await _userRepository.GetAllByRoleNameAsync("Projektledare");
        //var projectManagers = entities.Select(ProjectManagerFactory.Create);

        const string cacheKey = "ProjectManagers";
        if (!_cache.TryGetValue(cacheKey, out IEnumerable<ProjectManager>? projectManagers))
        {
            var entities = await _userRepository.GetAllByRoleNameAsync("Projektledare");
            projectManagers = entities.Select(ProjectManagerFactory.Create);
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(_cacheExpiration);

            _cache.Set(cacheKey, projectManagers, cacheEntryOptions);
        }

        return projectManagers!;
    }
}
