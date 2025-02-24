using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{

    public async Task<IEnumerable<ServiceEntity?>> GetAllServicesByServiceType(string serviceType)
    {
        try
        {
            var entities = await _context.Services
                 .Where(x => x.ServiceTypeName == serviceType)
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
