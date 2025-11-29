using IceTrackPlatform.API.Reporting.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Reporting.Domain.Model.Commands;

/// <summary>
/// Command to update a Report aggregate
/// </summary>
/// <param name="TenantId"> The tenant id of the report </param>
/// <param name="EquipmentId"> The equipment id of the report </param>
/// <param name="Title"> The title of the report </param>
/// <param name="Status"> The status of the report </param>
/// <param name="Summary"> The summary id of the report </param>
/// <param name="Content"> The content of the report </param>
/// <param name="Url"> The url of the report </param>

public record UpdateReportCommand(int Id, int TenantId, int EquipmentId, string Title, EReportStatus Status,
    string Summary, string Content, string Url);