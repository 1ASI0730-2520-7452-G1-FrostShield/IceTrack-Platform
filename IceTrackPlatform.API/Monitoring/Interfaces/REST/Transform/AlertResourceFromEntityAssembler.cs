using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Transform
{
    /// <summary>
    /// Assembler to transform Alert entity into AlertResource.
    /// </summary>
    public static class AlertResourceFromEntityAssembler
    {
        public static AlertResource ToResourceFromEntity(Alert entity) =>
            new AlertResource(
                entity.Id,
                entity.TenantId,
                entity.EquipmentId,
                entity.SiteId,
                entity.Type,
                entity.Severity,
                entity.Description,
                entity.Status,
                entity.CreatedAt
            );
    }
}