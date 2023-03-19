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
        string server = GetRequiredParameter<string>("ConnectionString:Server");
        string database = GetRequiredParameter<string>("ConnectionString:Database");
        string userId = GetRequiredParameter<string>("ConnectionString:User Id");
        string password = GetRequiredParameter<string>("ConnectionString:Password");

        string connectionString =
            $"Server={server};Database={database};User Id={userId};Password={password};MultipleActiveResultSets=true;TrustServerCertificate=true";

        return connectionString;
    }

    public bool AutoApplyMigrations()
    {
        string? parameter = GetParameter<string>("AutoApplyMigrations");
        bool isApply = true;

        if (parameter is not null)
        {
            try
            {
                isApply = bool.Parse(parameter);
            }
            catch (FormatException)
            {
                
            }
        }

        return isApply;
    }

    private T GetRequiredParameter<T>(string parameterName)
    {
        return _configuration.GetSection(parameterName).Get<T>() ?? throw new ParameterNotFoundException(parameterName);
    }
    
    private T? GetParameter<T>(string parameterName)
    {
        return _configuration.GetSection(parameterName).Get<T>();
    }
}