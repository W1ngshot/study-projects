using CookieApi.Database;
using CookieApi.Dto;
using CookieApi.Models;
using CookieApi.Repositories;
using CookieApi.Validators;
using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace CookieApi.Services;

public class ComponentService : IComponentService
{
    private readonly IComponentRepository _componentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRatingService _ratingService;
    private readonly IValidator<AddRamDto> _ramValidator;
    public ComponentService(IComponentRepository componentRepository, IUnitOfWork unitOfWork, 
        IRatingService ratingService, IValidator<AddRamDto> ramValidator)
    {
        _componentRepository = componentRepository;
        _unitOfWork = unitOfWork;
        _ratingService = ratingService;
        _ramValidator = ramValidator;
    }

    public async Task AddCpu(AddCpuDto dto)
    {
        var cpu = new Cpu
        {
            Name = dto.Name,
            Price = dto.Price,
            Benchmark = dto.Benchmark,
            CoresCount = dto.CoresCount,
            ThreadsCount = dto.ThreadsCount,
            MinimumFrequency = dto.MinimumFrequency,
            MaximumFrequency = dto.MaximumFrequency,
            NanometersCount = dto.NanometersCount,
            VideoMemoryCount = dto.VideoMemoryCount,
            Manufacturer = dto.Manufacturer,
            VotesCount = 0,
            Rating = new Rating
            {
                BenchmarkPlace = 0,
                VotesPlace = 0
            }
        };

        await _componentRepository.AddCpuAsync(cpu);
        await _unitOfWork.SaveChangesAsync();

        await _ratingService.RecalculateAllPlaces();
    }

    public async Task AddRam(AddRamDto dto)
    {
        await _ramValidator.ValidateAndThrowAsync(dto);
        
        var ram = new Ram
        {
            Name = dto.Name,
            Price = dto.Price,
            Benchmark = dto.Benchmark,
            Memory = dto.Memory,
            MemoryFrequency = dto.MemoryFrequency,
            Timings = dto.Timings,
            Manufacturer = dto.Manufacturer,
            VotesCount = 0,
            Rating = new Rating
            {
                BenchmarkPlace = 0,
                VotesPlace = 0
            }
        };

        await _componentRepository.AddRamAsync(ram);
        await _unitOfWork.SaveChangesAsync();

        await _ratingService.RecalculateAllPlaces();
    }

    public async Task<IEnumerable<Cpu>> GetAllCpus()
    {
        return await _componentRepository.GetAllCpusAsync();
    }

    public async Task<IEnumerable<Ram>> GetAllRams()
    {
        return await _componentRepository.GetAllRamsAsync();
    }

    public async Task<(Cpu, Cpu)> CompareCpus(Guid idFirst, Guid idSecond)
    {
        var cpu1 = await _componentRepository.GetCpuByIdAsync(idFirst)
            ?? throw new ValidationException($"cpu with id {idFirst} not found");
        var cpu2 = await _componentRepository.GetCpuByIdAsync(idSecond) 
                   ?? throw new ValidationException($"cpu with id {idSecond} not found");

        return (cpu1, cpu2);
    }

    public async Task<(Ram, Ram)> CompareRams(Guid idFirst, Guid idSecond)
    {
        var ram1 = await _componentRepository.GetRamByIdAsync(idFirst)
                   ?? throw new ValidationException($"ram with id {idFirst} not found");
        var ram2 = await _componentRepository.GetRamByIdAsync(idSecond) 
                   ?? throw new ValidationException($"ram with id {idSecond} not found");

        return (ram1, ram2);
    }

    public async Task Vote(Guid id)
    {
        var accessory = await _componentRepository.GetComponentByIdAsync(id) 
                        ?? throw new ValidationException($"accessory with id {id} not found");

        accessory.VotesCount++;

        await _unitOfWork.SaveChangesAsync();

        await _ratingService.RecalculateAllPlaces();
    }
}