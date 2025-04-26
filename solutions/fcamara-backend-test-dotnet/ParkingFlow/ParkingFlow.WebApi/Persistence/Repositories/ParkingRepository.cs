using Microsoft.EntityFrameworkCore;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Persistence.Repositories;

public class ParkingRepository(ParkingFlowDbContext context) : IParkingRepository
{
    private DbSet<Parking> _context = context.Set<Parking>();

    public void Add(Parking parking)
    {
        _context.Add(parking);
    }

    public void Remove(Parking parking)
    {
        _context.Remove(parking);
    }

    public void Update(Parking parking)
    {
        _context.Update(parking);
    }

    public async Task<Parking?> GetParkingByIdAsync(Guid id)
    {
        return await _context.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Parking?> GetParkingByNameAsync(string name)
    {
        return await _context.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(name));
    }

    public async Task<IList<Parking>> ListParkingsByCNPJAsync(string cnpj)
    {
        return await _context.AsNoTracking().Where(x => x.CNPJ.Equals(cnpj)).ToListAsync();
    }

    public async Task<bool> ExistsParkingByNameAsync(string name)
    {
        return await _context.AsNoTracking().AnyAsync(x => x.Name.Equals(name));
    }
}