using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;
using IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Transform;

/// <summary>
///     Assembler to create a CreateDashboardConfigCommand from a resource.
/// </summary>
public static class CreateDashboardConfigCommandFromResourceAssembler
{
    /// <summary>
    ///     Converts a resource to a command.
    /// </summary>
    /// <param name="resource">
    ///     The <see cref="CreateDashboardConfigResource" />.
    /// </param>
    /// <returns>
    ///     The <see cref="CreateDashboardConfigCommand" />.
    /// </returns>
    public static CreateDashboardConfigCommand ToCommandFromResource(CreateDashboardConfigResource resource)
    {
        return new CreateDashboardConfigCommand(
            resource.UserId,
            resource.DefaultSiteId,
            resource.DefaultTemperatureRangeValue);
    }
}