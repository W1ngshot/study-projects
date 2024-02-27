namespace TimetableApi;

public class Timetable
{
    public required string ReadKey { get; set; }
    
    public string? WriteKey { get; set; }
    
    public bool IsPrivate { get; set; }
    
    public required string Name { get; set; }
    
    public int? StartTime { get; set; }
    
    public int? EndTime { get; set; }
    
    public string? ParentTimetableReadKey { get; set; }
    
    public required string Classes { get; set; }
}