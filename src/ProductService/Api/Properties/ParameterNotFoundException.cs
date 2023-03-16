namespace Api.Properties;

public class ParameterNotFoundException : Exception
{
    public ParameterNotFoundException(string parameterName)
        : base($"Parameter {parameterName} not found in configuration")
    {
        
    }
}