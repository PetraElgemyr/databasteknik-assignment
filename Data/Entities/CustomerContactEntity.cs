using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(Email), IsUnique = true)]

public class CustomerContactEntity
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
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public ICollection<CustomerAddressEntity> CustomerAddresses { get; set; } = [];

}
