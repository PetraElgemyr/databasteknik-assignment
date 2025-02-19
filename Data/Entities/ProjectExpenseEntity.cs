using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectExpenseEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string ExpenseType { get; set; } = null!;

    [Column(TypeName = "decimal(20, 2)")]
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime ExpenseDate { get; set; }
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;

}
