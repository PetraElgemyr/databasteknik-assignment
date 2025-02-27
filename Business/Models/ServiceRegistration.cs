namespace Business.Models;

public class ServiceRegistration
{
    public int Id { get; set; }
    public string ServiceType { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public decimal HourlyCost { get; set; }
}