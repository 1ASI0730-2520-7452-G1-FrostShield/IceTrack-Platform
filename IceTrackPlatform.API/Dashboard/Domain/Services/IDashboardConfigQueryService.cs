using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Model.Queries;
using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Dashboard.Domain.Services;

/// <summary>
///     Dashboard configuration query service interface.
/// </summary>
public interface IDashboardConfigQueryService
{
    /// <summary>
    ///     Handles the get dashboard config by user ID query.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="GetDashboardConfigByUserIdQuery" /> query.
    /// </param>
    /// <returns>
    ///     The <see cref="DashboardConfig" /> if found, otherwise null.
    /// </returns>
    Task<DashboardConfig?> Handle(GetDashboardConfigByUserIdQuery query);

    /// <summary>
    ///     Handles the get dashboard config by ID query.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="GetDashboardConfigByIdQuery" /> query.
    /// </param>
    /// <returns>
    ///     The <see cref="DashboardConfig" /> if found, otherwise null.
    /// </returns>
    Task<DashboardConfig?> Handle(GetDashboardConfigByIdQuery query);

    /// <summary>
    ///     Handles the get available dashboard cards query.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="GetAvailableDashboardCardsQuery" /> query.
    /// </param>
    /// <returns>
    ///     A collection of available card types.
    /// </returns>
    Task<IEnumerable<CardType>> Handle(GetAvailableDashboardCardsQuery query);
}