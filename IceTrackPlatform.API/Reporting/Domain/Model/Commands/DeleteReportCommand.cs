namespace IceTrackPlatform.API.Reporting.Domain.Model.Commands;

/// <summary>
/// Command to delete a Report aggregate
/// </summary>
/// <param name="Id"> The identifier of the report </param>
public record DeleteReportCommand(int Id);