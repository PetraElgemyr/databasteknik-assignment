using Business.Models;

namespace Business.Interfaces;

public interface IServiceService
{
    Task<ResponseResult<IEnumerable<Service?>>> GetAllServicesAsync();
    Task<ResponseResult<IEnumerable<Service?>>> GetAllServicesByServiceTypeAsync(string serviceType);
}