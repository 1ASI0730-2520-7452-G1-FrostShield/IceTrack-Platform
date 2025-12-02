using IceTrackPlatform.API.Technicians.Domain.Model.Aggregates;
using IceTrackPlatform.API.Technicians.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Technicians.Interfaces.REST.Transform;

public static class TechnicianResourceFromEntityAssembler
{
    public static TechnicianResource ToResourceFromEntity(Technician entity)
    {
        return new TechnicianResource(
            entity.Id,
            entity.Name,
            entity.Specialty,
            entity.Phone,
            entity.ProviderId.Value);
    }
}

