using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

namespace IceTrackPlatform.API.Monitoring.Domain.Services;

public interface IEquipmentQueryServices
{
    /// <summary>
    ///     Handle the GetAllEquipmentByModelQuery
    /// </summary>
    Task<IEnumerable<Equipment>> Handle(GetAllEquipmentByModelQuery query);

    /// <summary>
    ///     Handle the GetEquipmentByModelAndSerialQuery
    /// </summary>
    Task<Equipment?> Handle(GetEquipmentByModelAndSerialQuery query);

    /// <summary>
    ///     Handle the GetEquipmentByIdQuery 
    /// </summary>
    Task<Equipment?> Handle(GetEquipmentByIdQuery query);
}
