namespace Api.Properties;

public class ConfigurationNotFoundException : Exception
{
    public ConfigurationNotFoundException(string configurationName) : base($"{configurationName} configuration not found")
    {
        
    }
}