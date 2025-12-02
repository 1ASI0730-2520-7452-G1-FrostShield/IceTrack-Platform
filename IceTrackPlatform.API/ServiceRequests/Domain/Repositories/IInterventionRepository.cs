using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.ServiceRequests.Domain.Repositories;

public interface IInterventionRepository : IBaseRepository<Intervention>
{
    Task<IEnumerable<Intervention>> FindByServiceRequestIdAsync(int serviceRequestId);
    new Task<IEnumerable<Intervention>> ListAsync();
}
