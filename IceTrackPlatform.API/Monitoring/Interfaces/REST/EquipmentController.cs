using System.Net.Mime;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Equipment")]
public class EquipmentController(
    IEquipmentCommandService equipmentCommandService,
    IEquipmentQueryServices equipmentQueryServices)
    : ControllerBase
{ 
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Equipment",
        Description = "Create a new Equipment",
        OperationId = "CreateEquipment")]
    [SwaggerResponse(201, "Created equipment", typeof(EquipmentResource))]
    [SwaggerResponse(400, "The equipment was not created")]
    [SwaggerResponse(409, "The equipment already exists")]
    public async Task<IActionResult> CreateEquipment(
        [FromBody] CreateEquipmentResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createEquipmentCommand =
            CreateEquipmentCommandFromResourceAssembler.ToCommandFromResource(resource);

        try
        {
            var result = await equipmentCommandService.Handle(createEquipmentCommand);
            if (result is null) return BadRequest();

            return CreatedAtAction(nameof(GetEquipmentById), new { id = result.Id },
                EquipmentResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        catch (Exception e) when (e.Message.Contains("already exists"))
        {
            return Conflict("An equipment with the same Model and Serial already exists.");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets an Equipment by Id",
        Description = "Gets an Equipment for a given identifier",
        OperationId = "GetEquipmentById")]
    [SwaggerResponse(200, "The equipment was found", typeof(EquipmentResource))]
    public async Task<IActionResult> GetEquipmentById(int id)
    {
        var getEquipmentByIdQuery = new GetEquipmentByIdQuery(id);
        var result = await equipmentQueryServices.Handle(getEquipmentByIdQuery);
        if (result is null) return NotFound();

        var resource = EquipmentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetEquipmentFromQuery(
        [FromQuery] string model,
        [FromQuery] string serial = "")
    {
        return string.IsNullOrEmpty(serial)
            ? await GetAllEquipmentByModel(model)
            : await GetEquipmentByModelAndSerial(model, serial);
    }

    private async Task<IActionResult> GetAllEquipmentByModel(string model)
    {
        var getAllEquipmentByModelQuery = new GetAllEquipmentByModelQuery(model);
        var results = await equipmentQueryServices.Handle(getAllEquipmentByModelQuery);

        var resources = results
            .Select(EquipmentResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
    }

    private async Task<IActionResult> GetEquipmentByModelAndSerial(string model, string serial)
    {
        var getEquipmentByModelAndSerialQuery =
            new GetEquipmentByModelAndSerialQuery(model, serial);

        var result = await equipmentQueryServices.Handle(getEquipmentByModelAndSerialQuery);
        if (result is null) return NotFound();

        var resource = EquipmentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}
