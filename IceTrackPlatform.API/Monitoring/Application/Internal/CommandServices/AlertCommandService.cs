using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.CommandServices;

public class AlertCommandService(
    IAlertRepository alertRepository,
    IUnitOfWork unitOfWork)
    : IAlertCommandService
{
    public async Task<Alert?> Handle(CreateAlertCommand command)
    {
        var existingAlerts = await alertRepository.FindByEquipmentIdAsync(command.EquipmentId);
        
        if (existingAlerts.Any(a =>
                a.Severity == command.Severity &&
                a.TenantId == command.TenantId))
        {
            throw new Exception(
                "An alert with the same severity and title already exists for this equipment and tenant.");
        }

        var alert = new Alert(command);

        await alertRepository.AddAsync(alert);
        await unitOfWork.CompleteAsync();

        return alert;
    }

    public async Task<Alert?> Handle(AcknowledgeAlertCommand command)
    {
        var alert = await alertRepository.FindByIdAsync(command.Id);
        if (alert == null) return null;

        alert.Acknowledge();

        await unitOfWork.CompleteAsync();

        return alert;
    }
}