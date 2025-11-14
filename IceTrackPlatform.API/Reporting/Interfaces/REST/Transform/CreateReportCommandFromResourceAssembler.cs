using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform CreateReportResource to CreateReportCommand.
/// </summary>
public static class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource) =>
        new CreateReportCommand(resource.TenantId, resource.Type, resource.EquipmentId,
            resource.Title, resource.Summary, resource.Content, resource.Url);
}