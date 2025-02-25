using Business.Models;
using Business.Models.Users;

namespace Business.Interfaces;

public interface IUserService
{
    Task<ResponseResult<User?>> CreateUserAsync(UserRegistrationForm form);
    Task<ResponseResult> DeleteUserAsync(User userForm);
    Task<ResponseResult> DeleteUserByIdAsync(int id);
    Task<ResponseResult<IEnumerable<ProjectManager>>> GetAllProjectManagersAsync();
    Task<ResponseResult<IEnumerable<ListUser>>> GetAllUsersForListAsync();
    Task<ResponseResult<User?>> UpdateUserAsync(User userForm);
}