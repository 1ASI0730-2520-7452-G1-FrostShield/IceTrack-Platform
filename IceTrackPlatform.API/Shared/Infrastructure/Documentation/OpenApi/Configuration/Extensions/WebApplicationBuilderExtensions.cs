using Microsoft.OpenApi.Models;

namespace IceTrackPlatform.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddOpenApiConfigurationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
    
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "IceTrackPlatform.API",
                    Version = "v1",
                    Description = "IceTrack Platform API",
                    TermsOfService = new Uri("https://icetrack.com/tos"),
                    Contact = new OpenApiContact
                    {
                        Name = "FrostShield",
                        Email = "contact@upc.edu.pe"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });
            options.EnableAnnotations();
        });
    }
}