using CookieApi.Database;
using CookieApi.Repositories;

namespace CookieApi.Services;

public class RatingService : IRatingService
{
    private readonly IComponentRepository _componentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RatingService(IComponentRepository componentRepository, IUnitOfWork unitOfWork)
    {
        _componentRepository = componentRepository;
        _unitOfWork = unitOfWork;
    }

    public Task RecalculateVotePlaces()
    {
        throw new NotImplementedException();
    }

    public Task RecalculateBenchmarkPlaces()
    {
        throw new NotImplementedException();
    }

    public async Task RecalculateAllPlaces()
    {
        var accessories = await _componentRepository.GetAllAccessories();

        var benchPlace = 1;
        foreach (var accessory in accessories.OrderByDescending(x => x.Benchmark))
        {
            accessory.Rating.BenchmarkPlace = benchPlace;
            benchPlace++;
        }

        var votesPlace = 1;
        foreach (var accessory in accessories.OrderByDescending(x => x.VotesCount))
        {
            accessory.Rating.VotesPlace = votesPlace;
            votesPlace++;
        }

        await _unitOfWork.SaveChangesAsync();
    }
}