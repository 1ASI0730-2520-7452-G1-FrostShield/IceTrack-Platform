namespace IceTrackPlatform.API.Dashboard.Interfaces.ACL;

/// <summary>
///     Facade for the Dashboard context.
/// </summary>
public interface IDashboardContextFacade
{
    /// <summary>
    ///     Creates a dashboard configuration for a user.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <param name="defaultSiteId">The default site ID (optional).</param>
    /// <param name="defaultTemperatureRangeValue">The default temperature range.</param>
    /// <returns>The ID of the created dashboard config, or 0 if creation failed.</returns>
    Task<int> CreateDashboardConfigForUser(int userId, int? defaultSiteId, string defaultTemperatureRangeValue);

    /// <summary>
    ///     Gets the dashboard configuration ID for a user.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <returns>The dashboard config ID, or 0 if not found.</returns>
    Task<int> FetchDashboardConfigIdByUserId(int userId);
}