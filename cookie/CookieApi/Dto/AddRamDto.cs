namespace CookieApi.Dto;

public class AddRamDto
{
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Benchmark { get; set; }
    
    public string Manufacturer { get; set; }
    
    public int Memory { get; set; }
    
    public int MemoryFrequency { get; set; }
    
    public string Timings { get; set; }
}