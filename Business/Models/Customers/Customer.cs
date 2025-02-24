namespace Business.Models.Customers;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public CustomerType CustomerType { get; set; } = null!;

}
