namespace Api.Parameters;

public static class ParametersProvider
{
    public static string GetConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("docker-compose") ?? throw new NullReferenceException();
    }
}