namespace CookieApi.Services;

public interface IRatingService
{
    Task RecalculateVotePlaces();

    Task RecalculateBenchmarkPlaces();

    Task RecalculateAllPlaces();
}