namespace IceTrackPlatform.API.Technicians.Interfaces.REST.Resources;

public record TechnicianResource(
    int Id,
    string Name,
    string Specialty,
    string Phone,
    int ProviderId);
