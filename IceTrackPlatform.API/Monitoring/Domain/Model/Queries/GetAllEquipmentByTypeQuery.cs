namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
///     Query to get all Equipment aggregates by Type
/// </summary>
/// <param name="Type">The Type to search</param>
public record GetAllEquipmentByTypeQuery(string Type);