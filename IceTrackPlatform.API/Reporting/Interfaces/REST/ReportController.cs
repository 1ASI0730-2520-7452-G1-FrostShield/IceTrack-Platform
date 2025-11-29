using System.Net.Mime;
using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Domain.Model.Queries;
using IceTrackPlatform.API.Reporting.Domain.Services;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;
using IceTrackPlatform.API.Reporting.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST;

/// <summary>
/// Report REST API controller.
/// </summary>
/// <param name="reportCommandService"> The Report Command Service </param>
/// <param name="reportQueryServices"> The Report Query Service </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Report")]
public class ReportController(
    IReportCommandService reportCommandService,
    IReportQueryServices reportQueryServices)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Report", Description = "Create a new Report", OperationId = "CreateReport")]
    [SwaggerResponse(201, "Created report", typeof(ReportResource))]
    [SwaggerResponse(400, "The Report was not created")]
    [SwaggerResponse(409, "The Report already exists")]
    public async Task<IActionResult> CreateReport(
        [FromBody] CreateReportResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
        var createReportCommand = CreateReportCommandFromResourceAssembler.ToCommandFromResource(resource);
        try
        {
            var result = await reportCommandService.Handle(createReportCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetReportById), new { id = result.Id },
                ReportResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        catch (Exception e) when (e.Message.Contains("already exists"))
        {
            return Conflict("A report with the same Title already exists.");
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a Report by Id", Description = "Gets a Report for a given identifier", OperationId = "GetReportById")]
    [SwaggerResponse(200, "The Report was found", typeof(ReportResource))]
    public async Task<IActionResult> GetReportById(int id)
    {
        var getReportByIdQuery = new GetReportByIdQuery(id);
        var result = await reportQueryServices.Handle(getReportByIdQuery);
        if (result is null) return NotFound();
        var resource = ReportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetReportFromQuery([FromQuery] int? tenantId = null, [FromQuery] int? equipmentId = null)
    {
        if (tenantId.HasValue)
            return await GetAllReportsByTenantIdQuery(tenantId.Value);

        if (equipmentId.HasValue)
            return await GetAllReportsByEquipmentQuery(equipmentId.Value);

        return BadRequest("Please specify either tenantId or equipmentId as query parameter.");
    }
    
    private async Task<IActionResult> GetAllReportsByTenantIdQuery(int tenantId)
    {
        var getAllReportsByTenantIdQuery = new GetAllReportsByTenantIdQuery(tenantId);
        var results = await reportQueryServices.Handle(getAllReportsByTenantIdQuery);

        var resources = results
            .Select(ReportResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
    }
    
    private async Task<IActionResult> GetAllReportsByEquipmentQuery(int equipmentId)
    {
        var getAllReportsByEquipmentIdQuery = new GetAllReportsByEquipmentIdQuery(equipmentId);
        var results = await reportQueryServices.Handle(getAllReportsByEquipmentIdQuery);

        var resources = results
            .Select(ReportResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
    }
    
    [HttpGet("all")]
    [SwaggerOperation(Summary = "Gets all reports", Description = "Get all reports", OperationId = "GetAllReports")]
    [SwaggerResponse(200, "The reports were found", typeof(IEnumerable<ReportResource>))]
    public async Task<IActionResult> GetAllReports()
    {
        var getAllReportsQuery = new GetAllReportsQuery();
        var reports = await reportQueryServices.Handle(getAllReportsQuery);

        var resources = reports .Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update a report", Description = "Update a report", OperationId = "UpdateReport")]
    [SwaggerResponse(200, "Updated report", typeof(ReportResource))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(404, "Report not found")]
    public async Task<IActionResult> UpdateReport(int id, [FromBody] UpdateReportResource resource)
    {
        if (resource is null) return BadRequest();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }

        var updateCommand = UpdateReportCommandFromResourceAssembler.ToCommandFromResource(id, resource);


        var result = await reportCommandService.Handle(updateCommand);
        if (result is null) return NotFound();
        var updatedResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(updatedResource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a report", Description = "Delete a report", OperationId = "DeleteReport")]
    [SwaggerResponse(204, "Report deleted")]
    [SwaggerResponse(404, "Report not found")]
    public async Task<IActionResult> DeleteReport(int id)
    {
        var deleteCommand = new DeleteReportCommand(id);
        var result = await reportCommandService.Handle(deleteCommand);
        if (result is null) return NotFound();
        return NoContent();
    }
}