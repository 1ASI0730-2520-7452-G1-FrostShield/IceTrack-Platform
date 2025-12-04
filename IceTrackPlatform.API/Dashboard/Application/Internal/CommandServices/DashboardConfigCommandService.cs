using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;
using IceTrackPlatform.API.Dashboard.Domain.Repositories;
using IceTrackPlatform.API.Dashboard.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Dashboard.Application.Internal.CommandServices;

/// <summary>
///     Dashboard configuration command service.
/// </summary>
/// <param name="dashboardConfigRepository">
///     The dashboard config repository.
/// </param>
/// <param name="unitOfWork">
///     The unit of work.
/// </param>
public class DashboardConfigCommandService(
    IDashboardConfigRepository dashboardConfigRepository,
    IUnitOfWork unitOfWork)
    : IDashboardConfigCommandService
{
    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(CreateDashboardConfigCommand command)
    {
        // Validate: user should have only one dashboard config
        if (await dashboardConfigRepository.ExistsByUserIdAsync(command.UserId))
            throw new InvalidOperationException($"Dashboard configuration already exists for user {command.UserId}.");

        var dashboardConfig = new DashboardConfig(command);

        try
        {
            await dashboardConfigRepository.AddAsync(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating dashboard config: {e.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(UpdateDashboardConfigCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null)
            throw new InvalidOperationException($"Dashboard configuration with ID {command.DashboardConfigId} not found.");

        try
        {
            dashboardConfig.Update(command);
            dashboardConfigRepository.Update(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating dashboard config: {e.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteDashboardConfigCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null) return false;

        try
        {
            dashboardConfigRepository.Remove(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting dashboard config: {e.Message}");
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(AddCardToDashboardCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null)
            throw new InvalidOperationException($"Dashboard configuration with ID {command.DashboardConfigId} not found.");

        try
        {
            dashboardConfig.AddCard(command);
            dashboardConfigRepository.Update(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error adding card to dashboard: {e.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(ReorderCardsCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null)
            throw new InvalidOperationException($"Dashboard configuration with ID {command.DashboardConfigId} not found.");

        try
        {
            dashboardConfig.ReorderCards(command);
            dashboardConfigRepository.Update(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reordering dashboard cards: {e.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(RemoveCardFromDashboardCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null)
            throw new InvalidOperationException($"Dashboard configuration with ID {command.DashboardConfigId} not found.");

        try
        {
            dashboardConfig.RemoveCard(command.CardId);
            dashboardConfigRepository.Update(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error removing card from dashboard: {e.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<DashboardConfig?> Handle(UpdateCardVisibilityCommand command)
    {
        var dashboardConfig = await dashboardConfigRepository.FindByIdAsync(command.DashboardConfigId);

        if (dashboardConfig is null)
            throw new InvalidOperationException($"Dashboard configuration with ID {command.DashboardConfigId} not found.");

        try
        {
            dashboardConfig.UpdateCardVisibility(command.CardId, command.IsVisible);
            dashboardConfigRepository.Update(dashboardConfig);
            await unitOfWork.CompleteAsync();
            return dashboardConfig;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating card visibility: {e.Message}");
            return null;
        }
    }
}