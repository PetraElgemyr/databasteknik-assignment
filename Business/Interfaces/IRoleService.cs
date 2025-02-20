using Business.Models;

namespace Business.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
}