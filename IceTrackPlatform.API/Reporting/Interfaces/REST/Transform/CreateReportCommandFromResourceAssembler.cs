using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Domain.Model.ValueObjects;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform CreateReportResource to CreateReportCommand.
/// </summary>
public static class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource)
    {
        if (!Enum.TryParse<EReportType>(resource.Type, ignoreCase: true, out var type))
        {
            throw new ArgumentException($"Invalid report type: {resource.Type}", nameof(resource.Type));
        }

        return new CreateReportCommand(
            resource.TenantId,
            type,
            resource.EquipmentId,
            resource.Title,
            resource.Summary,
            resource.Content,
            resource.Url);
    }
}