namespace Infrastructure.FilteringSystem;

public interface IStrictFilter
{
    public string PropertyName { get; }
    public string ExpectedValue { get; }
}