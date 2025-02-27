using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class PostalCodeFactory
{
    public static PostalCodeRegistrationForm? CreateRegistrationFormFromEntity(PostalCodeEntity entity) => entity == null ? null : new PostalCodeRegistrationForm
    {
        PostalCodeNumber = entity.PostalCode,
        City = entity.City,
    };


    public static PostalCodeEntity? CreatePostalCodeEntity(PostalCodeRegistrationForm form) => form == null ? null : new PostalCodeEntity
    {
        PostalCode = form.PostalCodeNumber,
        City = form.City,
    };
}
