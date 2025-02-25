using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Roles;
using Data.Interfaces;
using System.Data;
using System.Diagnostics;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<ResponseResult<IEnumerable<Role>>> GetAllRolesAsync()
    {
        try
        {
            var roleEntities = await _roleRepository.GetAllAsync();
            var roles = roleEntities.Select(RoleFactory.Create);
            return ResponseResult<IEnumerable<Role>>.Ok("", roles);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<Role>>.Error("Could not fetch roles");
        }

    }
}
