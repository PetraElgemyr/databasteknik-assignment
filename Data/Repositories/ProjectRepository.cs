using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Projects
                     .Include(p => p.Customer)
                     .Include(p => p.StatusType)
                     .Include(p => p.ProjectSchedule)
                     .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Projects
                .Include(p => p.ProjectSchedule)
                .Include(p => p.Customer)
                .Include(p => p.Customer.CustomerType)
                .Include(p => p.StatusType)
                .Include(p => p.User)
                .Include(p => p.User.Role)
                .FirstOrDefaultAsync(expression);

            if (entity == null)
            {
                return null!;
            }
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
    public  async Task<IEnumerable<ProjectEntity>?> GetAllProjectByCustomerIdAsync(int customerId)
    {
        try
        {
            var entities = await _context.Projects
                     .Include(p => p.Customer)
                     .Include(p => p.StatusType)
                     .Include(p => p.ProjectSchedule)
                     .Where(p => p.CustomerId == customerId)
                     .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
