using IceTrackPlatform.API.Dashboard.Domain.Model.Entities;
using IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Transform;

/// <summary>
///     Assembler to convert DashboardCard entity to resource.
/// </summary>
public static class DashboardCardResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts an entity to a resource.
    /// </summary>
    /// <param name="entity">
    ///     The <see cref="DashboardCard" /> entity.
    /// </param>
    /// <returns>
    ///     The <see cref="DashboardCardResource" />.
    /// </returns>
    public static DashboardCardResource ToResourceFromEntity(DashboardCard entity)
    {
        return new DashboardCardResource(
            entity.Id,
            entity.CardType.ToString(),
            entity.Order,
            entity.IsVisible);
    }
}