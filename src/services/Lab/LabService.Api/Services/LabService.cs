namespace LabService.Api.Services;
using Grpc.Core;

public class LabService : LabRpcService.LabRpcServiceBase
{
    private readonly ILogger<LabService> _logger;
    public LabService(ILogger<LabService> logger)
    {
        _logger = logger;
    }

    public override Task<SubmitLabOrderReply> SubmitLabOrder(
        SubmitLabOrderRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("Request lab order");
        return Task.FromResult(new SubmitLabOrderReply
        {
            Message = $"Order {request.Name} submitted"
        });
    }
}
