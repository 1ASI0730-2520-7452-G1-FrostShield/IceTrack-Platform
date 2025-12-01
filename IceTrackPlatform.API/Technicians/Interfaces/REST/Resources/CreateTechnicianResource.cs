namespace IceTrackPlatform.API.Technicians.Interfaces.REST.Resources;


public record CreateTechnicianResource(
    string Name, 
    string Specialty, 
    string Phone, 
    int ProviderId);
