using Haseroz.TestKit.Sample.Models;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .MinimumLevel.Debug()
  .CreateLogger();

builder.Host.UseSerilog(logger);

var microsoftLogger = new SerilogLoggerFactory(logger).CreateLogger<Program>();

microsoftLogger.LogInformation("Starting web host");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

const string StatusEndpointTag = "Status";

app.MapPost("/Status/Ok", () => Results.Ok(new ModelExample() { Name = "Name1" }))
    .WithOpenApi()
    .WithName("StatusOk")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/Created", () => Results.Created("/Status/Created/1", null))
    .WithOpenApi()
    .WithName("StatusCreated")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/NoContent", () => Results.NoContent())
    .WithOpenApi()
    .WithName("StatusNoContent")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/BadRequest", () => Results.BadRequest())
    .WithOpenApi()
    .WithName("StatusBadRequest")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/Unauthorized", () => Results.Unauthorized())
    .WithOpenApi()
    .WithName("StatusUnauthorized")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/Forbidden", () => Results.StatusCode(StatusCodes.Status403Forbidden))
    .WithOpenApi()
    .WithName("StatusForbidden")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/NotFound", () => Results.NotFound())
    .WithOpenApi()
    .WithName("StatusNotFound")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/Conflict", () => Results.Conflict())
    .WithOpenApi()
    .WithName("StatusConflict")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/UnprocessableEntity", () => Results.UnprocessableEntity())
    .WithOpenApi()
    .WithName("StatusUnprocessableEntity")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/InternalServerError", () => Results.StatusCode(StatusCodes.Status500InternalServerError))
    .WithOpenApi()
    .WithName("StatusInternalServerError")
    .WithTags(StatusEndpointTag);

app.MapPost("/Status/ServiceUnavailable", () => Results.StatusCode(StatusCodes.Status503ServiceUnavailable))
    .WithOpenApi()
    .WithName("StatusServiceUnavailable")
    .WithTags(StatusEndpointTag);

await app.RunAsync();
