namespace ParkingFlow.WebApi.Domain.Parkings;

public interface IParkingRepository
{
    void Add(Parking vehicle);
    void Remove(Parking vehicle);
    void Update(Parking vehicle);
    Task<Parking?> GetParkingByIdAsync(Guid id);
    Task<Parking?> GetParkingByNameAsync(string name);
    Task<IList<Parking>> ListParkingsByCNPJAsync(string cnpj);
    Task<bool> ExistsParkingByNameAsync(string name);
}