namespace CookieApi.Dto;

public class AddCpuDto
{
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Benchmark { get; set; }
    
    public int CoresCount { get; set; }
    
    public int ThreadsCount { get; set; }
    
    public int MinimumFrequency { get; set; }
    
    public int MaximumFrequency { get; set; }
    
    public int NanometersCount { get; set; }
    
    public int VideoMemoryCount { get; set; }
    
    public string Manufacturer { get; set; }
}