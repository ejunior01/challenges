using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Persistence.Database;

public class ParkingFlowDbContext(DbContextOptions<ParkingFlowDbContext> options) :
    DbContext(options), IUnitOfWork
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}