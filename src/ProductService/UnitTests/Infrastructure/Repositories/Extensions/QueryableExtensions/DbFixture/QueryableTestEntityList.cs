namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

public class QueryableTestEntityList
{
    public List<QueryableTestEntity> Entities { get; }

    public QueryableTestEntityList()
    {
        Entities = new List<QueryableTestEntity>() // ChatGPT THANK YOU VERY MUCH
        {
            new() { Id = 1, Property1 = 2, Property2 = "a", Property3 = 0, Property4 = 3 },
            new() { Id = 2, Property1 = 0, Property2 = "b", Property3 = 2, Property4 = 0 },
            new() { Id = 3, Property1 = 0, Property2 = "b", Property3 = 1, Property4 = 0 },
            new() { Id = 4, Property1 = 2, Property2 = "c", Property3 = 2, Property4 = 1 },
            new() { Id = 5, Property1 = 3, Property2 = "a", Property3 = 1, Property4 = 1 },
            new() { Id = 6, Property1 = 2, Property2 = "c", Property3 = 1, Property4 = 3 },
            new() { Id = 7, Property1 = 0, Property2 = "a", Property3 = 3, Property4 = 2 },
            new() { Id = 8, Property1 = 2, Property2 = "a", Property3 = 1, Property4 = 1 },
            new() { Id = 9, Property1 = 1, Property2 = "b", Property3 = 0, Property4 = 2 },
            new() { Id = 10, Property1 = 2, Property2 = "a", Property3 = 0, Property4 = 3 },
            new() { Id = 11, Property1 = 3, Property2 = "a", Property3 = 2, Property4 = 3 },
            new() { Id = 12, Property1 = 2, Property2 = "c", Property3 = 1, Property4 = 1 },
            new() { Id = 13, Property1 = 1, Property2 = "c", Property3 = 2, Property4 = 0 },
            new() { Id = 14, Property1 = 1, Property2 = "b", Property3 = 2, Property4 = 2 },
            new() { Id = 15, Property1 = 1, Property2 = "b", Property3 = 0, Property4 = 1 },
            new() { Id = 16, Property1 = 0, Property2 = "a", Property3 = 2, Property4 = 1 },
            new() { Id = 17, Property1 = 1, Property2 = "c", Property3 = 3, Property4 = 2 },
            new() { Id = 18, Property1 = 0, Property2 = "a", Property3 = 2, Property4 = 0 },
            new() { Id = 19, Property1 = 1, Property2 = "c", Property3 = 0, Property4 = 3 },
            new() { Id = 20, Property1 = 1, Property2 = "c", Property3 = 1, Property4 = 2 },
            new() { Id = 21, Property1 = 2, Property2 = "a", Property3 = 3, Property4 = 3 },
            new() { Id = 22, Property1 = 3, Property2 = "a", Property3 = 1, Property4 = 2 },
            new() { Id = 23, Property1 = 3, Property2 = "c", Property3 = 1, Property4 = 1 },
            new() { Id = 24, Property1 = 0, Property2 = "a", Property3 = 0, Property4 = 3 },
            new() { Id = 25, Property1 = 2, Property2 = "c", Property3 = 2, Property4 = 2 },
            new() { Id = 26, Property1 = 3, Property2 = "a", Property3 = 0, Property4 = 1 },
            new() { Id = 27, Property1 = 2, Property2 = "a", Property3 = 1, Property4 = 0 },
            new() { Id = 28, Property1 = 3, Property2 = "c", Property3 = 1, Property4 = 2 },
            new() { Id = 29, Property1 = 1, Property2 = "a", Property3 = 2, Property4 = 3 },
            new() { Id = 30, Property1 = 1, Property2 = "a", Property3 = 2, Property4 = 2 },
            new() { Id = 31, Property1 = 1, Property2 = "c", Property3 = 1, Property4 = 1 },
            new() { Id = 32, Property1 = 2, Property2 = "b", Property3 = 2, Property4 = 3 },
            new() { Id = 33, Property1 = 1, Property2 = "a", Property3 = 3, Property4 = 2 },
            new() { Id = 34, Property1 = 2, Property2 = "b", Property3 = 2, Property4 = 1 },
            new() { Id = 35, Property1 = 3, Property2 = "b", Property3 = 0, Property4 = 2 },
            new() { Id = 36, Property1 = 1, Property2 = "a", Property3 = 1, Property4 = 2 },
            new() { Id = 37, Property1 = 1, Property2 = "c", Property3 = 0, Property4 = 1 },
            new() { Id = 38, Property1 = 0, Property2 = "c", Property3 = 2, Property4 = 2 },
            new() { Id = 39, Property1 = 3, Property2 = "b", Property3 = 0, Property4 = 0 },
            new() { Id = 40, Property1 = 3, Property2 = "a", Property3 = 0, Property4 = 1 },
            new() { Id = 41, Property1 = 2, Property2 = "b", Property3 = 1, Property4 = 1 },
            new() { Id = 42, Property1 = 3, Property2 = "c", Property3 = 0, Property4 = 3 },
            new() { Id = 43, Property1 = 3, Property2 = "c", Property3 = 2, Property4 = 2 },
            new() { Id = 44, Property1 = 0, Property2 = "c", Property3 = 2, Property4 = 1 },
            new() { Id = 45, Property1 = 1, Property2 = "a", Property3 = 1, Property4 = 2 },
            new() { Id = 46, Property1 = 2, Property2 = "c", Property3 = 3, Property4 = 0 },
            new() { Id = 47, Property1 = 0, Property2 = "c", Property3 = 2, Property4 = 2 },
            new() { Id = 48, Property1 = 1, Property2 = "a", Property3 = 0, Property4 = 1 },
            new() { Id = 49, Property1 = 0, Property2 = "b", Property3 = 0, Property4 = 2 },
            new() { Id = 50, Property1 = 2, Property2 = "a", Property3 = 3, Property4 = 1 }
        };
    }
}