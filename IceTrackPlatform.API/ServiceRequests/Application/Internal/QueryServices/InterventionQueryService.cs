using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Domain.Model.Queries;
using IceTrackPlatform.API.ServiceRequests.Domain.Repositories;
using IceTrackPlatform.API.ServiceRequests.Domain.Services;

namespace IceTrackPlatform.API.ServiceRequests.Application.Internal.QueryServices;

public class InterventionQueryService(IInterventionRepository interventionRepository) : IInterventionQueryService
{
    public async Task<Intervention?> Handle(GetInterventionByIdQuery query)
    {
        return await interventionRepository.FindByIdAsync(query.InterventionId);
    }

    public async Task<IEnumerable<Intervention>> Handle(GetInterventionsByServiceRequestIdQuery query)
    {
        return await interventionRepository.FindByServiceRequestIdAsync(query.ServiceRequestId);
    }
}