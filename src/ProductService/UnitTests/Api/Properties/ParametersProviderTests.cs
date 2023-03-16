using System.Configuration;
using Api.Properties;
using Microsoft.Extensions.Configuration;

namespace UnitTests.Api.Properties;

public class ParametersProviderTests
{
    public string ExpectedConnectionString => "Server=a;Database=b;User Id=c;Password=d;MultipleActiveResultSets=true;TrustServerCertificate=true";

    [Fact]
    void GetConnectionString_ValidConfiguration_ExpectedConnectionString()
    {
        ParametersProvider parametersProvider = new(ConfigurationWithConnectionStringBuilder("a", "b", "c", "d"));

        string result = parametersProvider.GetConnectionString();
        
        Assert.Equal(ExpectedConnectionString, result);
    }
    
    [Fact]
    void GetConnectionString_SomeParametersDiscarded_ThrowParameterNotFoundException()
    {
        ParametersProvider parametersProvider = new(ConfigurationWithConnectionStringBuilder("a"));

        Assert.Throws<ParameterNotFoundException>(() => parametersProvider.GetConnectionString());
    }

    [Theory]
    [InlineData("true", true)]
    [InlineData("false", false)]
    void AutoApplyMigrations_ValidConfiguration_ParsedConfiguration(string? configurationValue, bool expectedResult)
    {
        ConfigurationManager configuration = new();
        configuration["AutoApplyMigrations"] = configurationValue;
        ParametersProvider parametersProvider = new(configuration);

        bool result = parametersProvider.AutoApplyMigrations();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("a")]
    void AutoApplyMigrations_InvalidConfiguration_True(string? configurationValue)
    {
        ConfigurationManager configuration = new();
        configuration["AutoApplyMigrations"] = configurationValue;
        ParametersProvider parametersProvider = new(configuration);

        bool result = parametersProvider.AutoApplyMigrations();
        
        Assert.Equal(true, result);
    }

    private IConfiguration ConfigurationWithConnectionStringBuilder(string? server = null, 
        string? database = null, string? userId = null, string? password = null)
    {
        ConfigurationManager configuration = new();
        configuration["ConnectionString:Server"] = server;
        configuration["ConnectionString:Database"] = database;
        configuration["ConnectionString:User Id"] = userId;
        configuration["ConnectionString:Password"] = password;
        return configuration;
    }
}