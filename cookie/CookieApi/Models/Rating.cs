namespace CookieApi.Models;

public class Rating : BaseEntity
{
    public int BenchmarkPlace { get; set; }
    
    public int VotesPlace { get; set; }
}