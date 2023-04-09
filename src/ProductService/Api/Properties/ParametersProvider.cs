namespace Api.Properties;

public class ParametersProvider
{
    public IConfiguration Configuration { get; }

    public ParametersProvider(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public string GetConnectionString()
    {
        string server = GetRequiredParameter<string>("ConnectionString:Server");
        string database = GetRequiredParameter<string>("ConnectionString:Database");
        string userId = GetRequiredParameter<string>("ConnectionString:User Id");
        string password = GetRequiredParameter<string>("ConnectionString:Password");

        string connectionString =
            $"Server={server};Database={database};User Id={userId};Password={password};MultipleActiveResultSets=true;TrustServerCertificate=true";

        return connectionString;
    }

    public bool AutoMigrate()
    {
        return GetRequiredParameter<bool>("AutoMigrate");
    }

    public bool AutoSeed()
    {
        return GetRequiredParameter<bool>("AutoSeed");
    }

    private T GetRequiredParameter<T>(string parameterName)
    {
        return Configuration.GetSection(parameterName).Get<T>() ?? throw new ParameterNotFoundException(parameterName);
    }
}