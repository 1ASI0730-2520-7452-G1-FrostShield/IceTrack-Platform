namespace IceTrackPlatform.API.Dashboard.Domain.Model.Queries;

/// <summary>
///     Query to get dashboard configuration by user ID.
/// </summary>
/// <param name="UserId">
///     The ID of the user whose dashboard to retrieve.
/// </param>
public record GetDashboardConfigByUserIdQuery(int UserId);