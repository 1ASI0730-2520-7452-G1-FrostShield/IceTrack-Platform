namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
/// Query to get an Alert aggregate by ID
/// </summary>
/// <param name="Id"> The Alert ID to search </param>
public record GetAlertByIdQuery(int Id);