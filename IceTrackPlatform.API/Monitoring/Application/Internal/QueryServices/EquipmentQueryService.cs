using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.QueryServices;

public class EquipmentQueryService(IEquipmentRepository equipmentRepository)
    : IEquipmentQueryServices
{
    public async Task<IEnumerable<Equipment>> Handle(GetAllEquipmentByModelQuery query)
    {
        return await equipmentRepository.FindByModelAsync(query.Model);
    }

    public async Task<Equipment?> Handle(GetEquipmentByModelAndSerialQuery query)
    {
        return await equipmentRepository.FindByModelAndSerialAsync(query.Model, query.Serial);
    }

    public async Task<Equipment?> Handle(GetEquipmentByIdQuery query)
    {
        return await equipmentRepository.FindByIdAsync(query.Id);
    }
}