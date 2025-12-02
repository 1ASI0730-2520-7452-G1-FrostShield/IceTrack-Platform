using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Domain.Model.Commands;

namespace IceTrackPlatform.API.ServiceRequests.Domain.Services;

public interface IInterventionCommandService
{
    Task<Intervention?> Handle(RecordInterventionCommand command);
}