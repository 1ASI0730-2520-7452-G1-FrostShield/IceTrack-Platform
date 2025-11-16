using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.CommandServices;

public class EquipmentCommandService(IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork)
    : IEquipmentCommandService
{
    public async Task<Equipment?> Handle(CreateEquipmentCommand command)
    {
        var equipment =
            await equipmentRepository.FindByModelAndSerialAsync(command.Model, command.Serial);

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
}
