namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
/// Query to get all Alert aggregates by the ID of an Equipment
/// </summary>
/// <param name="EquipmentId"> The Equipment ID to search </param>
public record GetAllAlertsByEquipmentIdQuery(int EquipmentId);