using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;
using IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Transform;

/// <summary>
///     Assembler to create an UpdateDashboardConfigCommand from a resource.
/// </summary>
public static class UpdateDashboardConfigCommandFromResourceAssembler
{
    /// <summary>
    ///     Converts a resource to a command.
    /// </summary>
    /// <param name="dashboardConfigId">
    ///     The ID of the dashboard configuration.
    /// </param>
    /// <param name="resource">
    ///     The <see cref="UpdateDashboardConfigResource" />.
    /// </param>
    /// <returns>
    ///     The <see cref="UpdateDashboardConfigCommand" />.
    /// </returns>
    public static UpdateDashboardConfigCommand ToCommandFromResource(
        int dashboardConfigId,
        UpdateDashboardConfigResource resource)
    {
        return new UpdateDashboardConfigCommand(
            dashboardConfigId,
            resource.DefaultSiteId,
            resource.DefaultTemperatureRangeValue);
    }
}