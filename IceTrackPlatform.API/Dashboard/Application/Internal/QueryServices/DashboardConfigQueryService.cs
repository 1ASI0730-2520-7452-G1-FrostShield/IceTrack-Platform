using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Model.Queries;
using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;
using IceTrackPlatform.API.Dashboard.Domain.Repositories;
using IceTrackPlatform.API.Dashboard.Domain.Services;

namespace IceTrackPlatform.API.Dashboard.Application.Internal.QueryServices;

/// <summary>
///     Dashboard configuration query service.
/// </summary>
/// <param name="dashboardConfigRepository">
///     The dashboard config repository.
/// </param>
public class DashboardConfigQueryService(IDashboardConfigRepository dashboardConfigRepository)
    : IDashboardConfigQueryService
{
    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(GetDashboardConfigByUserIdQuery query)
    {
        return await dashboardConfigRepository.FindByUserIdAsync(query.UserId);
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(GetDashboardConfigByIdQuery query)
    {
        return await dashboardConfigRepository.FindByIdAsync(query.DashboardConfigId);
    }

    /// <inheritdoc />
    public Task<IEnumerable<CardType>> Handle(GetAvailableDashboardCardsQuery query)
    {
        var availableCards = Enum.GetValues<CardType>().AsEnumerable();
        return Task.FromResult(availableCards);
    }
}