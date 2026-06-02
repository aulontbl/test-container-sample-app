namespace TestContainerSampleApp.Test;
using Testcontainers.Oracle;
using System.Data.OracleClient;

[TestClass]
[TestCategory("Integration")]
public class OracleIntegrationTests
{
    private static readonly OracleContainer _oracle = new OracleBuilder().WithImage("gvenzl/oracle-free:23.4-slim-faststart").Build();
    
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext context)
    {
        await _oracle.StartAsync();

        await using var connection = new OracleConnection(_oracle.GetConnectionString());
        await connection.OpenAsync();

        var initscript = @"
            CREATE TABLE coders (
            id RAW(16) PRIMARY KEY,
            type VARCHAR2(50),
            name VARCHAR2(255),
            language VARCHAR2(255),
            architecture VARCHAR2(255),
            is_vibe_coder NUMBER(1)
        );";
        
        



        await new OracleCommand(initscript, connection).ExecuteNonQueryAsync();
    }
    
    [ClassCleanup]
    public static async Task ClassCleanup()
    {
        await _oracle.DisposeAsync().AsTask();
    }

    [TestMethod]
    public void Create_User_ShouldReturnTrue()
    {
        
    }
    
    [TestMethod]
    public void Get_User_ShouldReturnUser()
    {
        
    }
    
}