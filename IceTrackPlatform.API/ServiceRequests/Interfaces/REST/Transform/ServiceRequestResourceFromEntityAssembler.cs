using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Transform;
public static class ServiceRequestResourceFromEntityAssembler
{
    public static ServiceRequestResource ToResourceFromEntity(ServiceRequest entity)
    {
        return new ServiceRequestResource(
            entity.Id,
            entity.RequesterId.Value,
            entity.SiteId.Value,
            entity.EquipmentId.Value,
            entity.AssignedTo.Value,
            entity.Origin,
            entity.Type.Type, // Pass enum directly
            entity.Priority.Priority, // Pass enum directly
            entity.Description,
            entity.Status.Status, // Pass enum directly
            entity.CompletedAt,
            entity.CanceledAt,
            entity.TechnicianId?.Value);
    }
}
