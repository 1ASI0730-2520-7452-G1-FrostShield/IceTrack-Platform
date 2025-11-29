using IceTrackPlatform.API.Dashboard.Application.Internal.CommandServices;
using IceTrackPlatform.API.Dashboard.Application.Internal.QueryServices;
using IceTrackPlatform.API.Dashboard.Domain.Repositories;
using IceTrackPlatform.API.Dashboard.Domain.Services;
using IceTrackPlatform.API.Dashboard.Infrastructure.Persistence.EFC.Repositories;

namespace IceTrackPlatform.API.Dashboard.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     Extension methods for configuring Dashboard context services.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///     Adds Dashboard context services to the application.
    /// </summary>
    /// <param name="builder">
    ///     The web application builder.
    /// </param>
    public static void AddDashboardContextServices(this WebApplicationBuilder builder)
    {
        // Repository
        builder.Services.AddScoped<IDashboardConfigRepository, DashboardConfigRepository>();

        // Services
        builder.Services.AddScoped<IDashboardConfigCommandService, DashboardConfigCommandService>();
        builder.Services.AddScoped<IDashboardConfigQueryService, DashboardConfigQueryService>();
    }
}