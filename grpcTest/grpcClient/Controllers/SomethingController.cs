using Microsoft.AspNetCore.Mvc;

namespace grpcClient.Controllers;

[ApiController]
[Route("[controller]")]
public class SomethingController : ControllerBase
{
    private readonly GrpcClient _grpcClient;

    public SomethingController(GrpcClient grpcClient)
    {
        _grpcClient = grpcClient;
    }

    [HttpGet(Name = "Calculate")]
    public async Task<float> Get(int first, int second, char operation)
    {
        return await _grpcClient.GetResult(first, second, operation);
    }
}