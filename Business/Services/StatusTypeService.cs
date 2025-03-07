﻿using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository, IMemoryCache cache) : IStatusTypeService
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;
    private readonly IMemoryCache _cache = cache;

    // TODO: Kolla med Hans om det är ok med cache expiration på 1 timme just för statusar som sällan ändras
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromHours(1);

    public async Task<ResponseResult<IEnumerable<StatusType>>> GetAllListStatusesAsync()
    {
        try
        {
            const string cacheKey = "StatusTypes";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<StatusType>? statuses))
            {
                var entities = await _statusTypeRepository.GetAllAsync();
                statuses = entities.Select(StatusTypeFactory.Create);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(_cacheExpiration);
                _cache.Set(cacheKey, statuses, cacheEntryOptions);
            }
            return ResponseResult<IEnumerable<StatusType>>.Ok("Statustypes successfully fetched", statuses);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<StatusType>>.Error("Could not fetch statustypes");
        }

    }
}
