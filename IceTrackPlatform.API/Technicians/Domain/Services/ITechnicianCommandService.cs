using IceTrackPlatform.API.Technicians.Domain.Model.Aggregates;
using IceTrackPlatform.API.Technicians.Domain.Model.Commands;

namespace IceTrackPlatform.API.Technicians.Domain.Services;

public interface ITechnicianCommandService
{
    Task<Technician?> Handle(CreateTechnicianCommand command);
    Task<Technician?> Handle(UpdateTechnicianCommand command);
    Task Handle(DeleteTechnicianCommand command);
}
