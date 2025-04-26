using Microsoft.EntityFrameworkCore;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Persistence.Repositories;

public class VehicleRepository(ParkingFlowDbContext context) : IVehicleRepository
{
    private DbSet<Vehicle> _context = context.Set<Vehicle>();

    public void Add(Vehicle vehicle)
    {
        _context.Add(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Remove(vehicle);
    }

    public async Task<Vehicle?> GetByPlateAsync(string plate)
    {
        Console.WriteLine(_context.Count());
        return await _context.FirstOrDefaultAsync((v) => v.Plate.Value.Equals(plate));
    }

    public async Task<bool> ExistsVehicleByPlateAsync(string plate)
    {
        return await _context.AnyAsync((v) => v.Plate.Value.Equals(plate));
    }
}