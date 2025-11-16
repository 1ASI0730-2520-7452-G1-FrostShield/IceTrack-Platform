using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;
using IceTrackPlatform.API.Dashboard.Domain.Model.Queries;
using IceTrackPlatform.API.Dashboard.Domain.Services;
using IceTrackPlatform.API.Dashboard.Interfaces.ACL;

namespace IceTrackPlatform.API.Dashboard.Application.ACL;

/// <summary>
///     Facade for the Dashboard context.
/// </summary>
/// <param name="commandService">
///     The dashboard command service.
/// </param>
/// <param name="queryService">
///     The dashboard query service.
/// </param>
public class DashboardContextFacade(
    IDashboardConfigCommandService commandService,
    IDashboardConfigQueryService queryService)
    : IDashboardContextFacade
{
    /// <inheritdoc />
    public async Task<int> CreateDashboardConfigForUser(
        int userId,
        int? defaultSiteId,
        string defaultTemperatureRangeValue)
    {
        var command = new CreateDashboardConfigCommand(userId, defaultSiteId, defaultTemperatureRangeValue);
        var dashboardConfig = await commandService.Handle(command);
        return dashboardConfig?.Id ?? 0;
    }

    /// <inheritdoc />
    public async Task<int> FetchDashboardConfigIdByUserId(int userId)
    {
        var query = new GetDashboardConfigByUserIdQuery(userId);
        var dashboardConfig = await queryService.Handle(query);
        return dashboardConfig?.Id ?? 0;
    }
}