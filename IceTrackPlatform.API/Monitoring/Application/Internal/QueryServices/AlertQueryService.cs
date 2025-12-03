using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;

namespace IceTrackPlatform.API.Monitoring.Application.Internal.QueryServices;

public class AlertQueryService(IAlertRepository alertRepository)
    : IAlertQueryServices
{
    public async Task<IEnumerable<Alert>> Handle(GetAllAlertsByTenantIdQuery query)
    {
        return await alertRepository.FindByTenantIdAsync(query.TenantId);
    }

    public async Task<IEnumerable<Alert>> Handle(GetAllAlertsByEquipmentIdQuery query)
    {
        return await alertRepository.FindByEquipmentIdAsync(query.EquipmentId);
    }

    public async Task<Alert?> Handle(GetAlertByIdQuery query)
    {
        return await alertRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query)
    {
        return await alertRepository.ListAsync();
    }
}