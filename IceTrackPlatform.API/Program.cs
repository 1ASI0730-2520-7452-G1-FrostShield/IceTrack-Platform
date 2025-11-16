using System.Text.Json.Serialization;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using IceTrackPlatform.API.Dashboard.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using IceTrackPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using IceTrackPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using IceTrackPlatform.API.Monitoring.Application.Internal.CommandServices;
using IceTrackPlatform.API.Monitoring.Application.Internal.QueryServices;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Repositories;
using IceTrackPlatform.API.Reporting.Application.Internal.CommandServices;
using IceTrackPlatform.API.Reporting.Application.Internal.QueryServices;
using IceTrackPlatform.API.Reporting.Domain.Repositories;
using IceTrackPlatform.API.Reporting.Domain.Services;
using IceTrackPlatform.API.Reporting.Infrastructure.Persistence.EFC.Repositories;
using IceTrackPlatform.API.Shared.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using IceTrackPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using IceTrackPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader());
});
// ------------------------------------

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Services (Configuración de la base de datos)
builder.AddDatabaseServices();

// Open API Configuration (Configuración de Swagger)
builder.AddOpenApiDocumentationServices();

builder.AddSharedContextServices();

// Report Bounded Context Injections
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportQueryServices, ReportQueryService>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();


// Alerts Bounded Context Injections
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertQueryServices, AlertQueryService>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();

builder.AddIamContextServices();
builder.AddDashboardContextServices();

// Mediator Configuration
builder.AddCortexConfigurationServices();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
app.UseDatabaseCreationAssurance();

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Configure the HTTP request pipeline.
app.UseOpenApiDocumentation();
app.UseHttpsRedirection();
// ------------------------------------

app.UseAuthorization();
app.UseRequestAuthorization();
app.MapControllers();
app.Run();