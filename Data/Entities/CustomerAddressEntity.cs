using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Data.Entities;


public class CustomerAddressEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(150)")]
    public string StreetName { get; set; } = null!;
    [Column(TypeName = "nvarchar(20)")]
    public string StreetNumber { get; set; } = null!;

    public string PostalCodeId { get; set; } = null!;
    public PostalCodeEntity PostalCode { get; set; } = null!;


    public int CustomerContactId { get; set; }
    public CustomerContactEntity CustomerContact { get; set; } = null!;
}