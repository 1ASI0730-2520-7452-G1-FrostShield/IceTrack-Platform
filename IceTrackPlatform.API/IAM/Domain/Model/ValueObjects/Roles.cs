namespace IceTrackPlatform.API.IAM.Domain.Model.ValueObjects;

/// <summary>
///     Defines the possible roles for an application user.
/// </summary>
public enum Roles
{
    /// <summary>
    ///     Default role for users who own equipment and request services (Client).
    /// </summary>
    Owner,

    /// <summary>
    ///     Role for users who provide maintenance and management services (Company/Provider).
    /// </summary>
    Provider
}