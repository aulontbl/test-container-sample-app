using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Scalar.AspNetCore;
using TestContainerSampleApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSingleton<ICoderService, CoderService>();

builder.Services.AddSingleton<ISessionFactory>(_ =>
{
    var cfg = new Configuration();

    cfg.DataBaseIntegration(db =>
    {
        db.ConnectionString = builder.Configuration.GetConnectionString("Oracle");
        db.Driver<OracleManagedDataClientDriver>();
        db.Dialect<Oracle12cDialect>();
    });

    return cfg.BuildSessionFactory();
});

var app = builder.Build();

app.MapGet("/coders", async ([FromServices] ICoderService service) =>
{
    var result = await service.GetAllCoders();
    var coders = result.ToList();
    return coders.Count == 0 ? Results.NotFound() : Results.Ok(coders);
});


app.MapGet("/coders/{id:guid}", async ([FromServices] ICoderService service, Guid id) =>
{
    var result = await service.GetCoderById(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapPost("/coders", async ([FromServices] ICoderService service, CreateCoderDto coder) =>
{
    var createdCoder = await service.CreateCoder(coder);
    return Results.Created($"/coders/{createdCoder.Id}", createdCoder);
});

app.MapPut("/coders/{id:guid}", async ([FromServices] ICoderService service, Guid id) =>
{
    var coder = await service.GetCoderById(id);
    if (coder is null) return Results.NotFound();
    await service.UpdateCoder(id, coder);
    return Results.NoContent();
});

app.MapDelete("/coders/{id:guid}", async ([FromServices] ICoderService service, Guid id) =>
{
    var coder = await service.GetCoderById(id);
    if (coder is null) return Results.NotFound();
    await service.DeleteCoder(id);
    return Results.NoContent();
});

app.MapOpenApi();
app.MapScalarApiReference();


app.UseHttpsRedirection();


app.Run();

