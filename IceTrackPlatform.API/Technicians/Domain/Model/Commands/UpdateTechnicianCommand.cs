namespace IceTrackPlatform.API.Technicians.Domain.Model.Commands;


public record UpdateTechnicianCommand(int Id, string Name, string Specialty, string Phone);
