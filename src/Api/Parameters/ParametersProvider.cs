namespace Api.Parameters;

public class ParametersProvider
{
    public static string GetConnectionString(IConfiguration configuration, string subSection = "DefaultConnection")
    {
        return configuration.GetConnectionString(subSection) ?? throw new NullReferenceException();
    }
}