namespace TimetableApi.Dto;

public class CreateTimetableDto
{
    public bool IsPrivate { get; set; }
    
    public required string Name { get; set; }
    
    public int? StartTime { get; set; }
    
    public int? EndTime { get; set; }
    
    public required string Classes { get; set; }
}