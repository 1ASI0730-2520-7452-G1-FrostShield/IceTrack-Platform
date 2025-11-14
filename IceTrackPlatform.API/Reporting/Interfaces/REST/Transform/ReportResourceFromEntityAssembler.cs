using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform Report entity to ReportResource.
/// </summary>
public static class ReportResourceFromEntityAssembler
{
    public static ReportResource ToResourceFromEntity(Report entity) =>
        new ReportResource(entity.Id, entity.TenantId, entity.Type, entity.EquipmentId,
            entity.Title, entity.Status.ToString(), entity.Summary, entity.Content, entity.Url);
}