using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Behaviors;
using ParkingFlow.WebApi.Domain.Parkings;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Middleware;
using ParkingFlow.WebApi.Persistence.Database;
using ParkingFlow.WebApi.Persistence.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddOpenApi();

builder.Services.AddMediatR((cfg) =>
{
    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

builder.Services.AddDbContext<ParkingFlowDbContext>((cfg) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    cfg.UseNpgsql(connectionString);
});


builder.Services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ParkingFlowDbContext>());
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IParkingRepository, ParkingRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapCarter();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();

public partial class Program
{
}