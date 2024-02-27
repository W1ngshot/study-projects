using TimetableApi.Dto;

namespace TimetableApi.Handlers;

public class CreateTimetableHandler
{
    private readonly TimetableService _timetableService;

    public CreateTimetableHandler(TimetableService timetableService)
    {
        _timetableService = timetableService;
    }

    public async Task CreateTimetable(CreateTimetableDto dto)
    {
        var timetable = new Timetable
        {
            Name = dto.Name,
            IsPrivate = dto.IsPrivate,
            ParentTimetableReadKey = null,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            ReadKey = KeyGenerator.GenerateReadKey(),
            WriteKey = KeyGenerator.GenerateWriteKey(),
            Classes = dto.Classes
        };

        await _timetableService.CreateAsync(timetable);
    }
}