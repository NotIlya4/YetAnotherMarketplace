using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Extensions;
using UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions;

[Collection(nameof(QueryableDbFixture))]
public class ApplyPaginationTests
{
    public QueryableDbContext DbContext { get; }
    public List<QueryableTestEntity> Entities { get; }
    
    public ApplyPaginationTests(QueryableDbFixture dbFixture)
    {
        Entities = new QueryableTestEntityList().Entities;
        DbContext = dbFixture.DbContext;
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(20, 1)]
    [InlineData(100, 30)]
    [InlineData(15, 20)]
    public void ValidInput_ListWithSkipAndTakeApplied(int offset, int limit)
    {
        Pagination pagination = new Pagination(offset, limit);
        List<QueryableTestEntity> expectedResult = Entities
            .Skip(offset)
            .Take(limit)
            .ToList();

        List<QueryableTestEntity> result = DbContext.TestEntities
            .ApplyPagination(pagination)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
}