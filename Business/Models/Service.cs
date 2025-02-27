using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class Service
{
    public int Id { get; set; }
    public string ServiceType { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public decimal HourlyCost { get; set; }
}
