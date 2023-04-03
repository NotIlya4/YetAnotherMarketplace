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
        return Configuration.GetSection("RedisConnectionString")["Server"] ??
                   throw new ConfigurationNotFoundException("RedisConnectionString:Server");
    }
}