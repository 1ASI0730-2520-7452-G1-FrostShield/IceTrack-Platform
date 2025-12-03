using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.QueryServices;

/// <summary>
///     Equipment Query Service
/// </summary>
/// <remarks>
///     This class handles queries related to new equipment.
///     It interacts with the IEquipmentRepository to retrieve data.
/// </remarks>
/// <param name="equipmentRepository"></param>
public class EquipmentQueryService(IEquipmentRepository equipmentRepository)
    : IEquipmentQueryServices
{
    public async Task<IEnumerable<Equipment>> Handle(GetAllEquipmentByTypeQuery query)
    {
        return await equipmentRepository.FindByTypeAsync(query.Type);
    }

    public async Task<Equipment?> Handle(GetEquipmentByManufacturerAndOnlineQuery query)
    {
        return await equipmentRepository.FindByManufacturerAndOnlineAsync(query.Manufacturer, query.Online);
    }

    public async Task<Equipment?> Handle(GetEquipmentByIdQuery query)
    {
        return await equipmentRepository.FindByIdAsync(query.Id);
    }
}