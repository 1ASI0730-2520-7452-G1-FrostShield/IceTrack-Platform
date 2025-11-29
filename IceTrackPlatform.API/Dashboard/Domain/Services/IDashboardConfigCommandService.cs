using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

namespace IceTrackPlatform.API.Dashboard.Domain.Services;

/// <summary>
///     Dashboard configuration command service interface.
/// </summary>
public interface IDashboardConfigCommandService
{
    /// <summary>
    ///     Handles the create dashboard config command.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="CreateDashboardConfigCommand" /> command.
    /// </param>
    /// <returns>
    ///     The created <see cref="DashboardConfig" /> or null if creation failed.
    /// </returns>
    Task<DashboardConfig?> Handle(CreateDashboardConfigCommand command);

    /// <summary>
    ///     Handles the update dashboard config command.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="UpdateDashboardConfigCommand" /> command.
    /// </param>
    /// <returns>
    ///     The updated <see cref="DashboardConfig" /> or null if update failed.
    /// </returns>
    Task<DashboardConfig?> Handle(UpdateDashboardConfigCommand command);

    /// <summary>
    ///     Handles the delete dashboard config command.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="DeleteDashboardConfigCommand" /> command.
    /// </param>
    /// <returns>
    ///     True if deletion was successful, otherwise false.
    /// </returns>
    Task<bool> Handle(DeleteDashboardConfigCommand command);

    /// <summary>
    ///     Handles the add card to dashboard command.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="AddCardToDashboardCommand" /> command.
    /// </param>
    /// <returns>
    ///     The updated <see cref="DashboardConfig" /> or null if operation failed.
    /// </returns>
    Task<DashboardConfig?> Handle(AddCardToDashboardCommand command);

    /// <summary>
    ///     Handles the reorder cards command.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="ReorderCardsCommand" /> command.
    /// </param>
    /// <returns>
    ///     The updated <see cref="DashboardConfig" /> or null if operation failed.
    /// </returns>
    Task<DashboardConfig?> Handle(ReorderCardsCommand command);
}