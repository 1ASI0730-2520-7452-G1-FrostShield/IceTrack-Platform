using IceTrackPlatform.API.Reporting.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Reporting.Domain.Model.Commands;

/// <summary>
/// Command to create a Report aggregate
/// </summary>
/// <param name="TenantId"> The tenant id of the new report </param>
/// <param name="Type"> The type of the new report</param>
/// <param name="EquipmentId"> The equipment id of the new report </param>
/// <param name="Title"> The title of the new report </param>
/// <param name="Summary"> The summary id of the new report </param>
/// <param name="Content"> The content of the new report </param>
/// <param name="Url"> The url of the new report </param>
public record CreateReportCommand(int TenantId, EReportType Type, int EquipmentId, string Title, 
    string Summary, string Content, string Url);