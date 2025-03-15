using Testcontainers.PostgreSql;

namespace ParkingFlow.Tests.Fixtures;

public class DatabasePostgresFixture : IAsyncLifetime
{
    private PostgreSqlContainer _postgreSqlContainer { get; set; }
    public string ConnectionString => _postgreSqlContainer.GetConnectionString();

    public async Task InitializeAsync()
    {
        _postgreSqlContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("test")
            .WithPassword("test")
            .WithImage("postgres:15")
            .Build();

        await _postgreSqlContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgreSqlContainer.DisposeAsync();
    }
}