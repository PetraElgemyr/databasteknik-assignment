using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(20,2)")]
    public decimal TotalCost { get; set; }
    public int CustomerId { get; set; }

    public CustomerEntity Customer { get; set; } = null!;
    public int StatusTypeId { get; set; }
    public StatusTypeEntity StatusType { get; set; } = null!;
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    public ICollection<ProjectServiceEntity> ProjectServices { get; set; } = [];
    public ICollection<ProjectLogEntity> ProjectLogs { get; set; } = [];
    public ICollection<ProjectExpenseEntity> ProjectExpenses { get; set; } = [];
    public ICollection<ProjectDocumentEntity> ProjectDocuments { get; set; } = [];


}