using IceTrackPlatform.API.Technicians.Domain.Model.Commands;
using IceTrackPlatform.API.Technicians.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Technicians.Interfaces.REST.Transform;

public static class UpdateTechnicianCommandFromResourceAssembler
{
    public static UpdateTechnicianCommand ToCommandFromResource(int id, UpdateTechnicianResource resource)
    {
        return new UpdateTechnicianCommand(id, resource.Name, resource.Specialty, resource.Phone);
    }
}