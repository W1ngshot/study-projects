namespace CookieApi.Models;

public class Accessory : BaseEntity
{
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Benchmark { get; set; }
    
    public int VotesCount { get; set; }
    
    public Guid RatingId { get; set; }
    
    public Rating Rating { get; set; }
}