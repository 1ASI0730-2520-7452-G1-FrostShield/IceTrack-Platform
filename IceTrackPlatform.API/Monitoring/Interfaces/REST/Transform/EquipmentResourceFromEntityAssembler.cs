using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class EquipmentResourceFromEntityAssembler
{
    public static EquipmentResource ToResourceFromEntity(Equipment entity) =>
        new EquipmentResource(
            entity.Id,
            entity.Model,
            entity.Type,
            entity.Serial,
            entity.Status
        );
}
