using IceTrackPlatform.API.ServiceRequests.Domain.Model.Commands;
using IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Transform;

public static class RecordInterventionCommandFromResourceAssembler
{
    public static RecordInterventionCommand ToCommandFromResource(RecordInterventionResource resource)
    {
        return new RecordInterventionCommand(
            resource.ServiceRequestId,
            resource.TechnicianId,
            resource.Summary,
            resource.StartTime,
            resource.EndTime,
            resource.PhotoUrls);
    }
}