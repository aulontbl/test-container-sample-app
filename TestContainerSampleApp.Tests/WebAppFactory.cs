using Alba;
using AwesomeAssertions;

namespace TestContainerSampleApp.Tests;
using Testcontainers.Oracle;

public class WebAppFactory : IAsyncLifetime
{
    private readonly OracleContainer _container = new OracleBuilder()
        .WithImage("gvenzl/oracle-free:23.4-slim-faststart")
        .Build();
    
    public Task InitializeAsync()
    {
        return _container.StartAsync();
    }
    public Task DisposeAsync()
    {
        return _container.StopAsync();
    }
    
    
    
    
    

    
    
    
}

public class Foo
{
    [Fact]
    public async Task TestSomething()
    {
        // Alba will automatically manage the lifetime of the underlying host
        await using var host = await AlbaHost.For<global::Program>();
    
        // This runs an HTTP request and makes an assertion
        // about the expected content of the response
        var result = await host.Scenario(_ =>
        {
            _.Get.Url("/sample");
            _.StatusCodeShouldBeOk();
        });


        var content = await result.ReadAsTextAsync();
        content.Should().Be("Hello World!");
    }
}