namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
///     Query to get an Equipment aggregate by Id
/// </summary>
/// <param name="Id">The Source Id to search</param>
public record GetEquipmentByIdQuery(int Id);