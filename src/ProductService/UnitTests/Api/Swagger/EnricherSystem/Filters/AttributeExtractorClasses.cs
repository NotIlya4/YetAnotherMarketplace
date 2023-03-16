namespace UnitTests.Api.Swagger.EnricherSystem.Filters;

[BlankAttribute]
[InterfaceImplementation(Id = 0)]
[InterfaceImplementation(Id = 1)]
[BlankAttribute]
public class ClassWithAttributes
{
    
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class InterfaceImplementationAttribute : Attribute, IInterface
{
    public required int Id { get; set; }
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class BlankAttributeAttribute : Attribute
{
    
}

public interface IInterface
{
    
}