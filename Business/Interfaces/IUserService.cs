using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    Task<ResponseResult<UserRegistrationForm?>> CreateUserAsync(UserRegistrationForm form);
    Task<ResponseResult> DeleteUserAsync(UserUpdateForm form);
    Task<ResponseResult> DeleteUserByIdAsync(int id);
    Task<IEnumerable<ProjectManager>> GetAllProjectManagersAsync();
    Task<ResponseResult<IEnumerable<ListUser>>> GetAllUsersForListAsync();
    Task<ResponseResult<UserUpdateForm?>> UpdateUserAsync(UserUpdateForm form);
}