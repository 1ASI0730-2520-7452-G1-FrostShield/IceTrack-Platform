using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Transform;

/// <summary>
///     Assembler to convert DashboardConfig entity to resource.
/// </summary>
public static class DashboardConfigResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts an entity to a resource.
    /// </summary>
    /// <param name="entity">
    ///     The <see cref="DashboardConfig" /> entity.
    /// </param>
    /// <returns>
    ///     The <see cref="DashboardConfigResource" />.
    /// </returns>
    public static DashboardConfigResource ToResourceFromEntity(DashboardConfig entity)
    {
        var cards = entity.Cards.Select(DashboardCardResourceFromEntityAssembler.ToResourceFromEntity);

        return new DashboardConfigResource(
            entity.Id,
            entity.UserId,
            entity.DefaultSiteId,
            entity.DefaultTemperatureRange.Value,
            cards);
    }
}