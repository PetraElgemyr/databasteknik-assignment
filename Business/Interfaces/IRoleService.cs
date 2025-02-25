using Business.Models;
using Business.Models.Roles;

namespace Business.Interfaces;

public interface IRoleService
{
    Task<ResponseResult<IEnumerable<Role>>> GetAllRolesAsync();
}