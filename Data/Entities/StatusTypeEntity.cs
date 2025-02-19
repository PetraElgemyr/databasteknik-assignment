using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(StatusType), IsUnique = true)]

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string StatusType { get; set; } = null!;
    public ICollection<ProjectEntity> Projects { get; set; } = [];

}
