using IceTrackPlatform.API.IAM.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
/// Resource representing an authenticated user with a JWT token.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="Username">The username of the user.</param>
/// <param name="Token">The JWT token for authentication.</param>
/// <param name="Role">The role of the authenticated user.</param> 
// En IAM/Interfaces/REST/Resources/AuthenticatedUserResource.cs
// CORRECCIÓN: Cambiar 'Roles' por 'string'
public record AuthenticatedUserResource(int Id, string Username, string Token, string Role);