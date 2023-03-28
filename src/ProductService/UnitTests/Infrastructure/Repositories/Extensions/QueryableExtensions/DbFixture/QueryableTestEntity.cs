namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

public record QueryableTestEntity
{
    public required int Id { get; set; }
    public required int Property1 { get; set; }
    public required string Property2 { get; set; }
    public required int Property3 { get; set; }
    public required int Property4 { get; set; }
}