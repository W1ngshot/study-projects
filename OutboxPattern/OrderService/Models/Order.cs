namespace OrderService.Models;

public class Order
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public double Price { get; set; }
    
    public double Weight { get; set; }
    
    public int CustomerId { get; set; }
}