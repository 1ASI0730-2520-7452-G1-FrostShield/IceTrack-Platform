namespace IceTrackPlatform.API.Technicians.Domain.Repositories;
using IceTrackPlatform.API.Shared.Domain.Repositories;
using IceTrackPlatform.API.Technicians.Domain.Model.Aggregates;


public interface ITechnicianRepository : IBaseRepository<Technician>
{
    Task<IEnumerable<Technician>> FindByProviderIdAsync(int providerId);
    new Task<IEnumerable<Technician>> ListAsync();
}