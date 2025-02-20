using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class PostalCodeFactory
{
    public static PostalCodeRegistrationForm Create(PostalCodeEntity entity)
    {
        return new PostalCodeRegistrationForm
        {
            PostalCodeNumber = entity.PostalCode,
            City = entity.City,
        };
    }

    public static PostalCodeEntity CreatePostalCodeEntity(PostalCodeRegistrationForm form)
    {
        return new PostalCodeEntity
        {
            PostalCode = form.PostalCodeNumber,
            City = form.City,
        };
    }
}
