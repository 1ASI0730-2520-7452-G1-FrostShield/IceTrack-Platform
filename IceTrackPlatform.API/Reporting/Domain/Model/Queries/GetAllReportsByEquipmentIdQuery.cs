namespace IceTrackPlatform.API.Reporting.Domain.Model.Queries;

/// <summary>
/// Query to get a Report aggregate by the ID of an Equipment
/// </summary>
/// <param name="EquipmentId"> The Equipment ID to search </param>
public record GetAllReportsByEquipmentIdQuery(int EquipmentId);