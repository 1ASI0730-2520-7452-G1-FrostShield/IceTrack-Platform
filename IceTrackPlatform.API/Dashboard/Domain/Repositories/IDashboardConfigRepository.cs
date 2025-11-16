using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Dashboard.Domain.Repositories;

/// <summary>
///     Repository interface for dashboard configurations.
/// </summary>
public interface IDashboardConfigRepository : IBaseRepository<DashboardConfig>
{
    /// <summary>
    ///     Finds a dashboard configuration by user ID.
    /// </summary>
    /// <param name="userId">
    ///     The ID of the user.
    /// </param>
    /// <returns>
    ///     The dashboard configuration if found, otherwise null.
    /// </returns>
    Task<DashboardConfig?> FindByUserIdAsync(int userId);

    /// <summary>
    ///     Checks if a dashboard configuration exists for a user.
    /// </summary>
    /// <param name="userId">
    ///     The ID of the user.
    /// </param>
    /// <returns>
    ///     True if a configuration exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByUserIdAsync(int userId);
}