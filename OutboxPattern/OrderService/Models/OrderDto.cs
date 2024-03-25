namespace OrderService.Models;

public class OrderDto
{
    public required string Name { get; set; }
    
    public double Price { get; set; }
    
    public double Weight { get; set; }
    
    public int CustomerId { get; set; }
}