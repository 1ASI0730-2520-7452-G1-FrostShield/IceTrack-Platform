using IceTrackPlatform.API.Technicians.Domain.Model.Aggregates;
using IceTrackPlatform.API.Technicians.Domain.Model.Queries;

namespace IceTrackPlatform.API.Technicians.Domain.Services;

public interface ITechnicianQueryService
{
    Task<Technician?> Handle(GetTechnicianByIdQuery query);
    Task<IEnumerable<Technician>> Handle(GetTechniciansByProviderIdQuery query);
}
