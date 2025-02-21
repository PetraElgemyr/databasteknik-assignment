using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Business.Services;

public class UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMemoryCache cache) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;


    private readonly IMemoryCache _cache = cache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

    public async Task<ResponseResult<IEnumerable<ListUser>>> GetAllUsersForListAsync()
    {
        var entities = await _userRepository.GetAllListUsersAsync();

        if (entities == null)
        {
            return ResponseResult<IEnumerable<ListUser>>.NotFound("No users found");
        }

        var listUsers = entities.Select(UserFactory.CreateListUser);

        return ResponseResult<IEnumerable<ListUser>>.Ok("Users found", listUsers);
    }

    public async Task<IEnumerable<ProjectManager>> GetAllProjectManagersAsync()
    {

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

    public async Task<ResponseResult<UserRegistrationForm?>> CreateUserAsync(UserRegistrationForm form)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == form.RoleId);
        var entity = UserFactory.CreateUserEntity(form);

        if (entity == null)
        {
            return ResponseResult<UserRegistrationForm?>.BadRequest("User registration form is invalid");
        }
        if (role == null)
        {
            return ResponseResult<UserRegistrationForm?>.NotFound("Role was not found");
        }

        var result = await _userRepository.AddAsync(entity);
        if (result == null)
        {
            return ResponseResult<UserRegistrationForm?>.Error("Something went wrong when creating user.");
        }

        return ResponseResult<UserRegistrationForm?>.Created("User was created successfully!", form);
    }

    public async Task<ResponseResult<UserUpdateForm?>> UpdateUserAsync(UserUpdateForm form)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == form.RoleId);
        var entity = UserFactory.CreateUserEntityFromUpdateForm(form);

        if (entity == null)
        {
            return ResponseResult<UserUpdateForm?>.BadRequest("User registration form is invalid");
        }
        if (role == null)
        {
            return ResponseResult<UserUpdateForm?>.NotFound("Role was not found");
        }

        var result = await _userRepository.UpdateAsync(entity);
        if (result == null)
        {
            return ResponseResult<UserUpdateForm?>.Error("Something went wrong when updating the user.");
        }

        return ResponseResult<UserUpdateForm?>.Created("User was successfully updated!", form);
    }


    public async Task<ResponseResult> DeleteUserAsync(UserUpdateForm form)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == form.RoleId);
        var entity = UserFactory.CreateUserEntityFromUpdateForm(form);

        if (entity == null)
        {
            return ResponseResult.InvalidModel("The provided user to delete is invalid");
        }
        if (role == null)
        {
            return ResponseResult<UserUpdateForm>.NotFound("Role was not found");
        }

        var deletedResult = await _userRepository.RemoveAsync(entity);
        if (!deletedResult)
        {
            return ResponseResult.Failed("Something went wrong when updating the user.");
        }

        return ResponseResult.NoContentSuccess();
    }

    public async Task<ResponseResult> DeleteUserByIdAsync(int id)
    {

        var entity = await _userRepository.GetAsync(x => x.Id == id);
        if (entity == null)
        {
            return ResponseResult.InvalidModel("The provided userId is invalid");
        }

        var deletedResult = await _userRepository.RemoveAsync(entity);
        if (!deletedResult)
        {
            return ResponseResult.Failed("Something went wrong when updating the user.");
        }

        return ResponseResult.NoContentSuccess();
    }
}
