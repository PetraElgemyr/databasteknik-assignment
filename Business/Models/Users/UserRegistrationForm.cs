using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models.Users;

public class UserRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public int RoleId { get; set; }
}


