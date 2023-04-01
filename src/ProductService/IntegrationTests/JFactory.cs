using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace IntegrationTests;

public class JFactory
{
    private JsonSerializer Serializer { get; }
    
    public JFactory()
    {
        Serializer = JsonSerializer.Create(new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
    
    public JArray Create(IEnumerable<object> objects)
    {
        List<JObject> jobjects = objects.Select(p => JObject.FromObject(p, Serializer)).ToList();
        return new JArray(jobjects);
    }

    public JObject Create(object obj)
    {
        return JObject.FromObject(obj, Serializer);
    }
}