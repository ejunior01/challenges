namespace ParkingFlow.WebApi.Domain.Vehicles;

public interface IVehicleRepository
{
    void Add(Vehicle vehicle);
    void Remove(Vehicle vehicle);
    Task<Vehicle?> GetByPlateAsync(string plate);
    Task<bool> ExistsVehicleByPlateAsync(string plate);
}