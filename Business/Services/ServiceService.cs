using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    private IServiceRepository _serviceRepository = serviceRepository;

    public async Task<ResponseResult<IEnumerable<Service?>>> GetAllServicesByServiceTypeAsync(string serviceType)
    {
        try
        {
            var entities = await _serviceRepository.GetAllServicesByServiceType(serviceType);
            var services = entities.Select(ServiceFactory.CreateServiceFromEntity!);
            return ResponseResult<IEnumerable<Service?>>.Ok($"Services for the selected service type {serviceType} found.", services);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<Service?>>.Error("Something went wrong when fetching services");
        }
    }

    public async Task<ResponseResult<IEnumerable<Service?>>> GetAllServicesAsync()
    {
        try
        {
            var entities = await _serviceRepository.GetAllAsync();
            var services = entities.Select(ServiceFactory.CreateServiceFromEntity);
            return ResponseResult<IEnumerable<Service?>>.Ok("Services retrieved successfully.", services);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<Service?>>.Error("An error occurred while retrieving services.");
        }
    }
}
