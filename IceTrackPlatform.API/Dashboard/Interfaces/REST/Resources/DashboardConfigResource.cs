namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource representing a dashboard configuration.
/// </summary>
/// <param name="Id">
///     The dashboard config ID.
/// </param>
/// <param name="UserId">
///     The user ID.
/// </param>
/// <param name="DefaultSiteId">
///     The default site ID.
/// </param>
/// <param name="DefaultTemperatureRange">
///     The default temperature range value.
/// </param>
/// <param name="Cards">
///     The collection of dashboard cards.
/// </param>
public record DashboardConfigResource(
    int Id,
    int UserId,
    int? DefaultSiteId,
    string DefaultTemperatureRange,
    IEnumerable<DashboardCardResource> Cards);