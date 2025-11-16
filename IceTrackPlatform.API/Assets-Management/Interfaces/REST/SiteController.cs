using System.Net.Mime;
using IceTrackPlatform.API.Assets_Management.Application.Internal.QueryServices;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;
using IceTrackPlatform.API.Assets_Management.Domain.Services;
using IceTrackPlatform.API.Assets_Management.Interfaces.REST.Resources;
using IceTrackPlatform.API.Assets_Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IceTrackPlatform.API.Assets_Management.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Site")]
public class SiteController(
    ISiteCommandService siteCommandService,
    ISiteQueryServices siteQueryServices)
    : ControllerBase 
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Site", Description = "Create a new Site", OperationId = "CreateSite")]
    [SwaggerResponse(201, "Created site", typeof(SiteResource))]
    [SwaggerResponse(400, "The site was not created")]
    [SwaggerResponse(409, "The site already exists")]
    public async Task<IActionResult> CreateSite(
        [FromBody] CreateSiteResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var createSiteCommand = CreateSiteCommandFromResourceAssembler.ToCommandFromResource(resource);
        try
        {
            var result = await siteCommandService.Handle(createSiteCommand);
            if (result is null)  return BadRequest();
            return CreatedAtAction(nameof(GetFavoriteAddress), new { id = result.Id }, 
                FavoriteSiteResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        catch (Exception e) when (e.Message.Contains("already exists"))
        {
            return Conflict("A site with the same Name and Address already exists.");
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a Site by Id", Description = "Gets a Site for a given identifier", OperationId = "GetFavoriteAddress")]
    [SwaggerResponse(200, "The site was found", typeof(SiteResource))]
    public async Task<IActionResult> GetFavoriteAddress(int id)
    {
        var getSiteByIdQuery = new GetSiteByIdQuery(id);
        var result = await siteQueryServices.Handle(getSiteByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSiteResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetSiteFromQuery([FromQuery] string name, [FromQuery] string address="")
    {
        return string.IsNullOrEmpty(address)
            ? await GetAllFavoriteSourcesByNewsApikey(name)
            : await GetSiteByNameAndAddress(name, address);
    }
    
    private async Task<IActionResult> GetAllFavoriteSourcesByNewsApikey(string newsApikey)
    {
        var getAllSiteByNameQuery = new GetAllSitesByNameQuery(newsApikey);
        var results = await siteQueryServices.Handle(getAllSiteByNameQuery);
        var resources = results
            .Select(FavoriteSiteResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();
        return Ok(resources);
    }
    
    private async Task<IActionResult> GetSiteByNameAndAddress(string name, string address)
    {
        var getSiteByNameAndAddressQuery = new GetSiteByNameAndAddressQuery(name, address);
        var result = await siteQueryServices.Handle(getSiteByNameAndAddressQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSiteResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}