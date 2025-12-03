namespace IceTrackPlatform.API.Technicians.Domain.Model.Commands;

public record CreateTechnicianCommand(string Name, string Specialty, string Phone, int ProviderId);
