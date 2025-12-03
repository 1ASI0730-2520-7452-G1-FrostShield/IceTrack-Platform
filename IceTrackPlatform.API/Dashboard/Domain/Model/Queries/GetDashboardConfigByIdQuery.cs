namespace IceTrackPlatform.API.Dashboard.Domain.Model.Queries;

/// <summary>
///     Query to get dashboard configuration by its ID.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration.
/// </param>
public record GetDashboardConfigByIdQuery(int DashboardConfigId);