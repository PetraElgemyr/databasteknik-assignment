using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string ServiceTypeName { get; set; } = null!;
    public string ServiceName { get; set; } = null!;

    [Column(TypeName = "decimal(20, 2)")]
    public decimal HourlyCost { get; set; }
}