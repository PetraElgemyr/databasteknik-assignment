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



    public  async Task<IEnumerable<ProjectEntity>?> GetAllProjectByCustomerId(int customerId)
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
}

