namespace AlertService.Api.Services;
using Grpc.Core;

public class AlertService : AlertRpcService.AlertRpcServiceBase
{
    private readonly ILogger<AlertService> _logger;
    public AlertService(ILogger<AlertService> logger)
    {
        _logger = logger;
    }

    public override Task<GetAlertsReply> GetAlerts(GetAlertsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Request alerts");
        return Task.FromResult(new GetAlertsReply
        {
            Message = $"Get alerts {request.Name}"
        });
    }
}
