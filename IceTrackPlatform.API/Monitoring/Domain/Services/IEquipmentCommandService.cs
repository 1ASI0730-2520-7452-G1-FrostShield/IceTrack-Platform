using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;

namespace IceTrackPlatform.API.Monitoring.Domain.Services;

public interface IEquipmentCommandService
{
    /// <summary>
    ///  Handle the create equipment command
    /// </summary>
    Task<Equipment?> Handle(CreateEquipmentCommand command);
}
