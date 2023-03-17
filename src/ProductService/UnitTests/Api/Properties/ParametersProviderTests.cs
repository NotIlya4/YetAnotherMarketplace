using System.Configuration;
using Api.Properties;
using Microsoft.Extensions.Configuration;

namespace UnitTests.Api.Properties;

public class ParametersProviderTests
{
    [Fact]
    void GetConnectionString_ValidConfiguration_ExpectedConnectionString()
    {
        string expectedConnectionString =
            "Server=a;Database=b;User Id=c;Password=d;MultipleActiveResultSets=true;TrustServerCertificate=true";
        ConfigurationManager configuration = new();
        configuration["ConnectionString:Server"] = "a";
        configuration["ConnectionString:Database"] = "b";
        configuration["ConnectionString:User Id"] = "c";
        configuration["ConnectionString:Password"] = "d";
        ParametersProvider parametersProvider = new(configuration);

        string result = parametersProvider.GetConnectionString();
        
        Assert.Equal(expectedConnectionString, result);
    }
    
    [Fact]
    void GetConnectionString_SomeParametersDiscarded_ThrowParameterNotFoundException()
    {
        ConfigurationManager configuration = new();
        configuration["ConnectionString:Server"] = "a";
        ParametersProvider parametersProvider = new(configuration);

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
}