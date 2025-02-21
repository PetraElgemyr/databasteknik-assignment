using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(Email), IsUnique = true)]

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;
    [Column(TypeName = "nvarchar(250)")]
    public string Email { get; set; } = null!;
    [Column(TypeName = "varchar(30)")]
    public string? PhoneNumber { get; set; }
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;
}