using CalculatorServer;
using Grpc.Core;

namespace grpcServer;

public class GrpcServer : CalculatorServer.SomethingService.SomethingServiceBase
{
    public override async Task<CalculatorReply> GetUserInfo(CalculatorRequest request, ServerCallContext context)
    {
        return request.Operation switch
        {
            "+" => new CalculatorReply {Result = request.First + request.Second},
            "-" => new CalculatorReply {Result = request.First - request.Second},
            "/" => new CalculatorReply {Result = (float)request.First / request.Second},
            "*" => new CalculatorReply {Result = request.First * request.Second},
            _ => new CalculatorReply {Result = int.MinValue}
        };
    }
}