using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;

namespace Business.Services;

public class PostalCodeService(IPostalCodeRepository postalCodeRepository) : IPostalCodeService
{
    private readonly IPostalCodeRepository _postalCodeRepository = postalCodeRepository;

    public async Task<ResponseResult> CreatePostalCodeAsync(PostalCodeRegistrationForm form)
    {
        try
        {
            var entity = PostalCodeFactory.CreatePostalCodeEntity(form);
            if (entity == null)
                return ResponseResult.InvalidModel("PostalCodeRegistrationForm was not properly provided");

            var createdPostalCodeEntity = await _postalCodeRepository.AddAsync(entity);
            if (createdPostalCodeEntity == null)
                return ResponseResult.Failed("Could not create postal code.");

            return ResponseResult.Succeeded("Postal code was successfully created.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed("Something went wrong when trying to create postalcode");
        }
    }
}
