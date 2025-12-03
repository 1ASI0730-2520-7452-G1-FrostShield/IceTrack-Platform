using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Domain.Model.Queries;

namespace IceTrackPlatform.API.ServiceRequests.Domain.Services;

public interface IInterventionQueryService
{
    Task<Intervention?> Handle(GetInterventionByIdQuery query);
    Task<IEnumerable<Intervention>> Handle(GetInterventionsByServiceRequestIdQuery query);
}