namespace TestContainerSampleApp.Test;
using Testcontainers.Oracle;

[TestClass]
[TestCategory("Integration")]
public class OracleIntegrationTests
{
    private static OracleBuilder _oracle;
    
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext context)
    {
        _oracle = new OracleBuilder("gvenzl/oracle-free:23.4-slim-faststart");
        await _oracle.StartAsync();
    }
    
    [ClassCleanup]
    public static async Task ClassCleanup()
    {
        await _oracle.StopAsync();
    }

    
}