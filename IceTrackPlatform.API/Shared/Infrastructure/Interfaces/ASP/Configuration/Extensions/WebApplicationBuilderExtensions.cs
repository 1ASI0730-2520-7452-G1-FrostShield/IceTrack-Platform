using IceTrackPlatform.API.Shared.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IceTrackPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;


public static class WebApplicationBuilderExtensions
{
    public static void AddSharedContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}