using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IPostalCodeService
{
    Task<ResponseResult> CreatePostalCodeAsync(PostalCodeRegistrationForm form);
}