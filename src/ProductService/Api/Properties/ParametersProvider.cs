using Infrastructure;

namespace Api.Properties;

public class ParametersProvider
{
    private readonly IConfiguration _configuration;

    public ParametersProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GetConnectionString()
    {
        string connectionStringName =
            _configuration.GetSection("ConnectionStringName").Value ?? "local";
        return _configuration.GetConnectionString(connectionStringName) ?? throw new NullReferenceException();
    }

    public bool IsAutoMigrationsApply()
    {
        return !_configuration.GetSection("DisableAutoApplyMigrations").Value.EqualsIgnoreCase("true");
    }
}