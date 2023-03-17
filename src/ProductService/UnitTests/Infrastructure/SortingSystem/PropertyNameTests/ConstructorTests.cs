using Domain.Exceptions;
using Infrastructure.SortingSystem;

namespace UnitTests.Infrastructure.SortingSystem.PropertyNameTests;

public class ConstructorTests
{
    [Theory]
    [InlineData(nameof(TestClass.Property1))]
    [InlineData(nameof(TestClass.Property2))]
    [InlineData(nameof(TestClass.Property3))]
    public void ValidNameWithCase_InitWithSameValue(string name)
    {
        PropertyName<TestClass> propertyName = new(name);

        string propertyNameValue = propertyName.Value;
        
        Assert.Equal(name, propertyNameValue);
    }

    [Theory]
    [InlineData("pRopeRTY1", nameof(TestClass.Property1))]
    [InlineData("PrOPerty2", nameof(TestClass.Property2))]
    [InlineData("proPerty3", nameof(TestClass.Property3))]
    public void ValidNameWithBadCase_InitWithCaseThatUsedInClass(string badCase, string rightCase)
    {
        PropertyName<TestClass> propertyName = new(badCase);

        string propertyNameValue = propertyName.Value;
        
        Assert.Equal(rightCase, propertyNameValue);
    }

    [Fact]
    public void InvalidName_ThrowValidationException()
    {
        Assert.Throws<ValidationException>(() => new PropertyName<TestClass>("asdasdas"));
    }
}