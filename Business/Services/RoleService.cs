using Business.Factories;
using Business.Interfaces;
using Business.Models.Roles;
using Data.Interfaces;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        var roleEntities = await _roleRepository.GetAllAsync();
        var roles = roleEntities.Select(RoleFactory.Create);
        return roles;
    }
}
