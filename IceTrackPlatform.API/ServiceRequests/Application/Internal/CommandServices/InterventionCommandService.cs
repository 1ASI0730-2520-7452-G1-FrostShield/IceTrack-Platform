using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Domain.Model.Commands;
using IceTrackPlatform.API.ServiceRequests.Domain.Repositories;
using IceTrackPlatform.API.ServiceRequests.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.ServiceRequests.Application.Internal.CommandServices;

public class InterventionCommandService(
    IInterventionRepository interventionRepository,
    IUnitOfWork unitOfWork) : IInterventionCommandService
{
    public async Task<Intervention?> Handle(RecordInterventionCommand command)
    {
        var intervention = new Intervention(
            command.ServiceRequestId,
            command.TechnicianId,
            command.Summary,
            command.StartTime,
            command.EndTime,
            command.PhotoUrls);
        
        await interventionRepository.AddAsync(intervention);
        await unitOfWork.CompleteAsync();
        return intervention;
    }
}
