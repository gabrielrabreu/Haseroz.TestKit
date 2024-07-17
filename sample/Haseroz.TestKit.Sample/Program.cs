using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Haseroz.TestKit.Sample.Core.DTOs;
using Haseroz.TestKit.Sample.Core.Services;
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
builder.Services.AddScoped<SkuService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/Skus", (CreateSkuRequestDto request, SkuService skuService) =>
{
    var result = skuService.Create(request);

    if (result.IsCreated())
        return Results.Created(result.Location, result.GetValue());

    return result.ToMinimalApiResult();
})
.WithOpenApi()
.WithName("CreateSku")
.WithTags("Skus")
.WithSummary("Creates Sku");

app.MapDelete("/Skus/{SkuId}", (Guid skuId, SkuService skuService) =>
{
    return skuService.Delete(skuId).ToMinimalApiResult();
})
.WithOpenApi()
.WithName("DeleteSku")
.WithTags("Skus")
.WithSummary("Deletes Skus by its ID");

app.Run();

public partial class Program
{
    protected Program()
    {
    }
}
