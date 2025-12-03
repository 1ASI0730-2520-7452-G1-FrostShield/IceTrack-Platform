using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.CommandServices;

/// <summary>
/// This class handles commands related to Equipment entities.
/// </summary>
/// <param name="equipmentRepository">The instance of EquipmentRepository</param>
/// <param name="unitOfWork">The instance of UnitOfwork</param>
public class EquipmentCommandService(IEquipmentRepository equipmentRepository,
                                        IUnitOfWork unitOfWork)
    : IEquipmentCommandService
{
    public async Task<Equipment?> Handle(CreateEquipmentCommand command)
    {
        var equipment =
            await equipmentRepository.FindByManufacturerAndOnlineAsync(command.Manufacturer, command.Online);
        if (equipment != null)
            throw new Exception("Equipment already exists.");
        equipment = new Equipment(command);
        try
        {
            await equipmentRepository.AddAsync(equipment);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
        return equipment;
    }
    
    public async Task<bool> Handle(DeleteEquipmentCommand command)
    {
        var equipment = await equipmentRepository.FindByIdAsync(command.EquipmentId);

        if (equipment is null) return false;

        try
        {
            equipmentRepository.Remove(equipment);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting Equipment: {e.Message}");
            return false;
        }
    }
}