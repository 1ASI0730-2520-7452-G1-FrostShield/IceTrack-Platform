using IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.Queries;

public record GetServiceRequestsByProviderIdQuery(int ProviderId, EServiceRequestStatus? Status);