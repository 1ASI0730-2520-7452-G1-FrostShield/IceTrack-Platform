using IceTrackPlatform.API.Technicians.Domain.Model.Commands;
using IceTrackPlatform.API.Technicians.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Technicians.Interfaces.REST.Transform;


public static class CreateTechnicianCommandFromResourceAssembler
{
    public static CreateTechnicianCommand ToCommandFromResource(CreateTechnicianResource resource)
    {
        return new CreateTechnicianCommand(resource.Name, resource.Specialty, resource.Phone, resource.ProviderId);
    }
}
