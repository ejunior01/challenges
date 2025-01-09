namespace ParkingFlow.WebApi.Common.Abstracts;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}