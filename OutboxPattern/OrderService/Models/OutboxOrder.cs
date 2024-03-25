namespace OrderService.Models;

public class OutboxOrder
{
    public Guid Id { get; set; }
    
    public Guid IdempotencyKey { get; set; }

    public required string Name { get; set; }

    public int UserId { get; set; }

    public DateTime AddDate { get; set; }
}