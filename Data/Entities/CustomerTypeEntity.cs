using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;


public class CustomerTypeEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string CustomerTypeName { get; set; } = null!;
    public ICollection<CustomerEntity> Customers { get; set; } = [];
}
