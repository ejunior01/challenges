using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Persistence.Repositories;

public class VehicleRepository(ParkingFlowDbContext context) : IVehicleRepository
{
    public void Add(Vehicle vehicle)
    {
        context.Set<Vehicle>().Add(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        context.Set<Vehicle>().Remove(vehicle);
    }

    public Task<Vehicle?> GetByPlate(string plate)
    {
        return context.Set<Vehicle>().FirstOrDefaultAsync((v) => v.Plate.Value.Equals(plate));
    }

    public Task<bool> ExistsVehicleByPlate(string plate)
    {
        return context.Set<Vehicle>().AnyAsync((v) => v.Plate.Value.Equals(plate));
    }
}