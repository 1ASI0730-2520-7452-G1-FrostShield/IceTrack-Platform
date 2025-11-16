using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform CreateAlertResource to CreateAlertCommand.
/// </summary>
public static class CreateAlertCommandFromResourceAssembler
{
    public static CreateAlertCommand ToCommandFromResource(CreateAlertResource resource) =>
        new CreateAlertCommand(
            resource.TenantId,
            resource.EquipmentId,
            resource.SiteId,
            resource.Type,
            resource.Severity,
            resource.Description,
            resource.Status
        );
}
