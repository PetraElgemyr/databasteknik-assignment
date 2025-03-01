using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;

public class ProjectServiceRepository(DataContext context) : BaseRepository<ProjectServiceEntity>(context), IProjectServiceRepository
{

    public async Task<IEnumerable<ProjectServiceEntity>?> GetAllProjectServicesByProjectIdAsync(int projectId)
    {
        try
        {
            var entities = await _context.ProjectServices
                .Include(ps => ps.Service)
                .Where(ps => ps.ProjectId == projectId)
                .ToListAsync();

            return entities;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> RemoveAllProjectServicesByProjectId(int projectId)
    {
        try
        {
            var projectServicesToDelete = await _context.ProjectServices.Where(ps => ps.ProjectId == projectId).ToListAsync();
            if (projectServicesToDelete.Count == 0)
                return true;

            projectServicesToDelete.ForEach(ps => _context.ProjectServices.Remove(ps));
            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return false;
            return true;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> RemoveAsyncByFKKeys(int projectId, int serviceId)
    {
        try
        {
            var projectServiceEntity = await _context.ProjectServices.FirstOrDefaultAsync(
                ps => ps.ProjectId == projectId &&
                ps.ServiceId == serviceId);

            if (projectServiceEntity == null)
                return false;

            _context.ProjectServices.Remove(projectServiceEntity);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return false;
        }
    }
}
