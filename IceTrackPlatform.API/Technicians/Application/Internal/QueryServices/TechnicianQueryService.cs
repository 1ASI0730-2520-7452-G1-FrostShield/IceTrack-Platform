using IceTrackPlatform.API.Technicians.Domain.Model.Aggregates;
using IceTrackPlatform.API.Technicians.Domain.Model.Queries;
using IceTrackPlatform.API.Technicians.Domain.Repositories;
using IceTrackPlatform.API.Technicians.Domain.Services;

namespace IceTrackPlatform.API.Technicians.Application.Internal.QueryServices;


public class TechnicianQueryService(ITechnicianRepository technicianRepository) : ITechnicianQueryService
{
    public async Task<Technician?> Handle(GetTechnicianByIdQuery query)
    {
        return await technicianRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Technician>> Handle(GetTechniciansByProviderIdQuery query)
    {
        return await technicianRepository.FindByProviderIdAsync(query.ProviderId);
    }
}

