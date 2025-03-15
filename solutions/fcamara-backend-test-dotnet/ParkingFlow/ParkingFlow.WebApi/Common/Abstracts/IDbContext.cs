using Microsoft.EntityFrameworkCore;

namespace ParkingFlow.WebApi.Common.Abstracts;
public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;
}