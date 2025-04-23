using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;
using ParkingFlow.WebApi.Domain.Vehicles;
using System.Reflection;

namespace ParkingFlow.WebApi.Persistence.Database;

public class ParkingFlowDbContext(DbContextOptions<ParkingFlowDbContext> options) :
    DbContext(options), IUnitOfWork
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Parking> Parkings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}