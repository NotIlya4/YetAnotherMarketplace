namespace Api.Parameters;

public static class ParametersProvider
{
    public static string GetConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("sql-server") ?? throw new NullReferenceException();
    }
}