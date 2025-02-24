using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Users;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

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

        var listUsers = entities.Select(UserFactory.CreateListUserFromEntity);

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

    public async Task<ResponseResult<User?>> CreateUserAsync(UserRegistrationForm form)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == form.RoleId);
        var entity = UserFactory.CreateUserEntityFromRegistrationForm(form);

        if (entity == null)
        {
            return ResponseResult<User?>.BadRequest("User registration form is invalid");
        }
        if (role == null)
        {
            return ResponseResult<User?>.NotFound("Role was not found");
        }

        var result = await _userRepository.AddAsync(entity);
        if (result == null)
        {
            return ResponseResult<User?>.Error("Something went wrong when creating user.");
        }
        var createdUser = UserFactory.CreateUserFromEntity(entity);

        return ResponseResult<User?>.Created("User was created successfully!", createdUser);
    }

    public async Task<ResponseResult<User?>> UpdateUserAsync(User userForm)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == userForm.RoleId);
        var entity = UserFactory.CreateUserEntityFromUser(userForm);
        var exists = await _userRepository.ExistsAsync(c => c.Id == entity.Id);

        if (!exists)
        {
            return ResponseResult<User?>.NotFound("The user to update could not be found.");
        }

        if (entity == null)
        {
            return ResponseResult<User?>.BadRequest("User registration form is invalid");
        }
        if (role == null)
        {
            return ResponseResult<User?>.NotFound("Role was not found");
        }

        var result = await _userRepository.UpdateAsync(entity);
        if (result == null)
        {
            return ResponseResult<User?>.Error("Something went wrong when updating the user.");
        }

        return ResponseResult<User?>.Created("User was successfully updated!", userForm);
    }


    public async Task<ResponseResult> DeleteUserAsync(User userForm)
    {

        var role = await _roleRepository.GetAsync(r => r.Id == userForm.RoleId);
        var entity = UserFactory.CreateUserEntityFromUser(userForm);

        if (entity == null)
        {
            return ResponseResult.InvalidModel("The provided user to delete is invalid");
        }
        if (role == null)
        {
            return ResponseResult<User>.NotFound("Role was not found");
        }

        var deletedResult = await _userRepository.RemoveAsync(entity);
        if (!deletedResult)
        {
            return ResponseResult.Failed("Something went wrong when deleting the user.");
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
            return ResponseResult.Failed("Something went wrong when trying to delete the user.");
        }

        return ResponseResult.NoContentSuccess();
    }
}
