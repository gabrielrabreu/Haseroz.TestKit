using Serilog;
using Serilog.Extensions.Logging;
using System.Net;

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

app.MapPost("/Status/OK", () => Results.Ok())
    .WithOpenApi()
    .WithName("StatusOK")
    .WithTags("Status");

app.MapPost("/Status/Created", () => Results.Created("/Status/Created/1", null))
    .WithOpenApi()
    .WithName("StatusCreated")
    .WithTags("Status");

app.MapPost("/Status/BadRequest", () => Results.BadRequest())
    .WithOpenApi()
    .WithName("StatusBadRequest")
    .WithTags("Status");

app.MapPost("/Status/Unauthorized", () => Results.Unauthorized())
    .WithOpenApi()
    .WithName("StatusUnauthorized")
    .WithTags("Status");

app.MapPost("/Status/Forbidden", () => Results.StatusCode((int)HttpStatusCode.Forbidden))
    .WithOpenApi()
    .WithName("StatusForbidden")
    .WithTags("Status");

app.MapPost("/Status/NotFound", () => Results.NotFound())
    .WithOpenApi()
    .WithName("StatusNotFound")
    .WithTags("Status");

app.MapPost("/Status/Conflict", () => Results.Conflict())
    .WithOpenApi()
    .WithName("StatusConflict")
    .WithTags("Status");

app.MapPost("/Status/UnprocessableEntity", () => Results.UnprocessableEntity())
    .WithOpenApi()
    .WithName("StatusUnprocessableEntity")
    .WithTags("Status");

app.MapPost("/Status/InternalServerError", () => Results.StatusCode((int)HttpStatusCode.InternalServerError))
    .WithOpenApi()
    .WithName("StatusInternalServerError")
    .WithTags("Status");

app.MapPost("/Status/ServiceUnavailable", () => Results.StatusCode((int)HttpStatusCode.ServiceUnavailable))
    .WithOpenApi()
    .WithName("StatusServiceUnavailable")
    .WithTags("Status");

await app.RunAsync();
