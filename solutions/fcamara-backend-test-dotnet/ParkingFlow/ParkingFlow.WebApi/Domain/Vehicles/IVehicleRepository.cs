namespace ParkingFlow.WebApi.Domain.Vehicles;

public interface IVehicleRepository
{
    void Add(Vehicle vehicle);
    void Remove(Vehicle vehicle);
    Task<Vehicle?> GetByPlate(string plate);
    Task<bool> ExistsVehicleByPlate(string plate);
}