namespace CookieApi.Models;

public class Ram : Accessory
{
    public string Manufacturer { get; set; }
    
    public int Memory { get; set; }
    
    public int MemoryFrequency { get; set; }
    
    public string Timings { get; set; }
}