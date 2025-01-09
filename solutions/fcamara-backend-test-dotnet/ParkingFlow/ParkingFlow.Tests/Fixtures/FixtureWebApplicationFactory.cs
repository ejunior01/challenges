using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.Tests.Fixtures;

public class FixtureWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly DatabasePostgresFixture _postgresFixture;

    public FixtureWebApplicationFactory()
    {
        _postgresFixture = new DatabasePostgresFixture();
        _postgresFixture.InitializeAsync().GetAwaiter().GetResult();
    }
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            
            var dbContextDescriptor  = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ParkingFlowDbContext>));
            
            if (dbContextDescriptor  != null)
                services.Remove(dbContextDescriptor );
            
            services.AddDbContext<ParkingFlowDbContext>((container, options) =>
            {
                options.UseNpgsql(_postgresFixture.ConnectionString);
            });
            
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ParkingFlowDbContext>();
            
            db.Database.Migrate();
        });

        return base.CreateHost(builder);
    }
}