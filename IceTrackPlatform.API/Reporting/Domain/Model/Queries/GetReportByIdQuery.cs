namespace IceTrackPlatform.API.Reporting.Domain.Model.Queries;

/// <summary>
/// Query to get a Report aggregate by ID
/// </summary>
/// <param name="Id"> The Report ID to search </param>
public record GetReportByIdQuery(int Id);