using IceTrackPlatform.API.Feedback.Domain.Model.Queries;
using IceTrackPlatform.API.Feedback.Domain.Services;
using IceTrackPlatform.API.Feedback.Interfaces.REST.Resources;
using IceTrackPlatform.API.Feedback.Interfaces.REST.Transform;

namespace IceTrackPlatform.API.Feedback.Interfaces.REST;

using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Reviews")]
public class ReviewsController(
    IReviewCommandService reviewCommandService,
    IReviewQueryService reviewQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Review",
        Description = "Creates a new Review",
        OperationId = "CreateReview")]
    [SwaggerResponse(StatusCodes.Status201Created, "The review was created", typeof(ReviewResource))]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var command = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(command);
        if (review == null) return BadRequest();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = reviewResource.Id }, reviewResource);
    }

    [HttpGet("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Get Review by Id",
        Description = "Gets a Review by its Id",
        OperationId = "GetReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found")]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        var query = new GetReviewByIdQuery(reviewId);
        var review = await reviewQueryService.Handle(query);
        if (review == null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    
    [HttpGet("serviceRequest/{serviceRequestId:int}")]
    [SwaggerOperation(
        Summary = "Get Reviews by Service Request Id",
        Description = "Gets all Reviews for a given Service Request Id",
        OperationId = "GetReviewsByServiceRequestId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetReviewsByServiceRequestId(int serviceRequestId)
    {
        var query = new GetReviewsByServiceRequestIdQuery(serviceRequestId);
        var reviews = await reviewQueryService.Handle(query);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Reviews",
        Description = "Gets all Reviews",
        OperationId = "GetAllReviews")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetAllReviews()
    {
        var query = new GetAllReviewsQuery();
        var reviews = await reviewQueryService.Handle(query);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
}
