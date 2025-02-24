using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    // override för att hämta customer & statustyp så att customerNamn o statusnamn visas i listan med alla projekt. endast därför
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Projects
                     .Include(p => p.Customer)
                     .Include(p => p.StatusType)
                     .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    // override för att hämta customer, status och user (för detaljvy när jag klickat in på proj)
    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Projects
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

    // TODO  kolla varför inte funkar
    public async Task<ProjectEntity?> UpdateProjectByIdAsync(ProjectEntity entity)
    {
        try
        {
            var existingEntity = await _context.Set<ProjectEntity>().FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (existingEntity == null)
            {
                Debug.WriteLine("Entity not found in database");
                return null;
            }

            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
