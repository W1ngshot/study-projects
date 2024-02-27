using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TimetableApi;

public class TimetableService
{
    private readonly IMongoCollection<Timetable> _timetableCollection;

    public TimetableService(
        IOptions<TimetableStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _timetableCollection = mongoDatabase.GetCollection<Timetable>(
            bookStoreDatabaseSettings.Value.TimetableCollectionName);
    }

    public async Task<List<Timetable>> GetAsync() =>
        await _timetableCollection.Find(_ => true)
            .ToListAsync();

    public async Task<Timetable?> GetAsync(string readKey) =>
        await _timetableCollection.Find(x => x.ReadKey == readKey)
            .FirstOrDefaultAsync();

    public async Task<Timetable?> GetAsync(string readKey, string writeKey) =>
        await _timetableCollection
            .Find(x => x.ReadKey == readKey && x.WriteKey == writeKey)
            .FirstOrDefaultAsync();

    public async Task CreateAsync(Timetable timetable) =>
        await _timetableCollection.InsertOneAsync(timetable);

    public async Task UpdateAsync(string readKey, Timetable updatedTimetable) =>
        await _timetableCollection.ReplaceOneAsync(x => x.ReadKey == readKey, updatedTimetable);

    public async Task RemoveAsync(string readKey) =>
        await _timetableCollection.DeleteOneAsync(x => x.ReadKey == readKey);
}