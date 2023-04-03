namespace Api.Properties;

public class ParametersProvider
{
    public IConfiguration Configuration { get; }

    public ParametersProvider(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public string GetRedisConnectionString()
    {
        string server = GetRequiredConfiguration("RedisConnectionString:Server");
        string databaseNumber = GetRequiredConfiguration("RedisConnectionString:DatabaseNumber");

        return $"{server},defaultDatabase={databaseNumber}";
    }

    public string GetRequiredConfiguration(string path)
    {
        return Configuration.GetSection(path).Value ?? throw new ConfigurationNotFoundException(path);
    }
}