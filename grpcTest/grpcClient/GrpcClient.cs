using CalculatorClient;

namespace grpcClient;

public class GrpcClient
{
    private readonly CalculatorClient.SomethingService.SomethingServiceClient _calculatorService;

    public GrpcClient(SomethingService.SomethingServiceClient calculatorService)
    {
        _calculatorService = calculatorService;
    }

    public async Task<float> GetResult(int first, int second, char operation)
    {
        return (await _calculatorService.GetUserInfoAsync(new CalculatorRequest
        {
            First = first,
            Second = second,
            Operation = operation.ToString()
        })).Result;
    }
}