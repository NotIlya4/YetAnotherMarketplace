namespace Api.Parameters;

public static class ParametersProvider
{
    public static string GetConnectionString(IConfiguration configuration)
    {
        string connectionStringName =
            configuration.GetSection("ConnectionStringName").Value ?? throw new NullReferenceException();
        return configuration.GetConnectionString(connectionStringName) ?? throw new NullReferenceException();
    }
}