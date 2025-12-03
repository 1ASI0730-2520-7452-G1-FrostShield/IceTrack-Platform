using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Domain.Model.ValueObjects;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform UpdateReportResource to UpdateReportCommand.
/// </summary>
public static class UpdateReportCommandFromResourceAssembler
{
    public static UpdateReportCommand ToCommandFromResource(int id, UpdateReportResource resource)
    {
        if (!Enum.TryParse<EReportStatus>(resource.Status, ignoreCase: true, out var status))
        {
            throw new ArgumentException($"Invalid report status: {resource.Status}", nameof(resource.Status));
        }

        return new UpdateReportCommand(
            id,
            resource.TenantId,
            resource.EquipmentId,
            resource.Title,
            status,
            resource.Summary,
            resource.Content,
            resource.Url);
    }
}