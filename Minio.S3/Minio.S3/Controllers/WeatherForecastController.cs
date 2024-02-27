using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.Args;

namespace Minio.S3.Controllers;

[ApiController]
[Route("/api")]
public class WeatherForecastController : ControllerBase
{
    private readonly AspNetCore.IMinioClientFactory _minioClientFactory;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, AspNetCore.IMinioClientFactory minioClientFactory)
    {
        _logger = logger;
        _minioClientFactory = minioClientFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost("/upload")]
    public async Task<IActionResult> Post([FromForm] FileModel file)
    {
        var client = _minioClientFactory.CreateClient();
        var bucketName = "test";
        var contentType = "image/png";
        var objName = $"{file.FileName}";
        var fileName = $"/img/{file.FileName}";
        try
        {
            await using (var stream = file.File.OpenReadStream())
            {
                await client.PutObjectAsync(new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objName)
                    .WithStreamData(stream)
                    .WithFileName(fileName)
                    .WithObjectSize(stream.Length));
            }

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}