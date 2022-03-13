namespace AdtService.Api.Services;
using Grpc.Core;

public class AdtService : AdtRpcService.AdtRpcServiceBase
{
    private readonly ILogger<AdtService> _logger;
    public AdtService(ILogger<AdtService> logger)
    {
        _logger = logger;
    }

    public override Task<AdmitPatientReply> AdmitPatient(
        AdmitPatientRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("Request patient admission");
        return Task.FromResult(new AdmitPatientReply
        {
            Message = $"Admiting patient {request.Name}"
        });
    }
}
