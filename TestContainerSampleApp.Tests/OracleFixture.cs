using Testcontainers.Oracle;

namespace TestContainerSampleApp.Tests;

public class OracleFixture : IAsyncLifetime
{
    public OracleContainer Container { get; private set; } = default!;

    public string ConnectionString => Container.GetConnectionString();

    public async Task InitializeAsync()
    {
        Container = new OracleBuilder()
            .WithImage("gvenzl/oracle-free:23-slim-faststart")
            .WithUsername("test")
            .WithPassword("test")
            .Build();

        await Container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }
}