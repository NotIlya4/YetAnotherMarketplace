using Api.Swagger.EnricherSystem.Filters;

namespace UnitTests.Api.Swagger.EnricherSystem.Filters;

public class AttributeExtractorTests
{
    public AttributeExtractor AttributeExtractor { get; }
    
    public AttributeExtractorTests()
    {
        AttributeExtractor = new AttributeExtractor();
    }

    [Fact]
    public void GetAttributeAssignableTo_ClassWithMultipleAttributes_FirstSatisfiedAttribute()
    {
        IInterface? result = AttributeExtractor.GetAttributeAssignableTo<IInterface>(typeof(ClassWithAttributes));
        
        Assert.NotNull(result);
        var attribute = Assert.IsType<InterfaceImplementationAttribute>(result);
        Assert.Equal(0, attribute.Id);
    }
}