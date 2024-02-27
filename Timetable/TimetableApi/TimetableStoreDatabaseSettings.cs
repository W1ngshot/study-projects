namespace TimetableApi;

public class TimetableStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string TimetableCollectionName { get; set; } = null!;
}