using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;
using UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions;

[Collection(nameof(QueryableDbFixture))]
public class ApplySortingTests
{
    public QueryableDbContext DbContext { get; }
    public QueryableTestEntityList EntityList { get; }
    public IQueryable<QueryableTestEntity> StartQuery { get; }

    public ApplySortingTests(QueryableDbFixture fixture)
    {
        EntityList = new QueryableTestEntityList();
        DbContext = fixture.DbContext;
        StartQuery = DbContext
            .TestEntities
            .AsQueryable();
    }
    
    [Theory]
    [InlineData(SortingSide.Asc)]
    [InlineData(SortingSide.Desc)]
    public async Task PropertyIncrementAllAscAndDesc_SortedEntities(SortingSide sortingSide)
    {
        List<QueryableTestEntity> expectedOrder;
        if (sortingSide == SortingSide.Asc)
        {
            expectedOrder = EntityList.Entities
                .OrderBy(e => e.Property1)
                .ThenBy(e => e.Property2)
                .ThenBy(e => e.Property3)
                .ThenBy(e => e.Property4)
                .ToList();
        }
        else
        {
            expectedOrder = EntityList.Entities
                .OrderByDescending(e => e.Property1)
                .ThenByDescending(e => e.Property2)
                .ThenByDescending(e => e.Property3)
                .ThenByDescending(e => e.Property4)
                .ToList();
        }
        
        IQueryable<QueryableTestEntity> query = StartQuery.ApplySorting(
            primarySorting: new Sorting(nameof(QueryableTestEntity.Property1), sortingSide),
            secondarySortings: new List<Sorting>
            {
                new(nameof(QueryableTestEntity.Property2), sortingSide),
                new(nameof(QueryableTestEntity.Property3), sortingSide),
                new(nameof(QueryableTestEntity.Property4), sortingSide),
            });
        
        List<QueryableTestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
    
    [Fact]
    public async Task RandomPropertyOrderAndRandomSortingSide1_SortedEntities()
    {
        IQueryable<QueryableTestEntity> query = StartQuery.ApplySorting(
            primarySorting: new Sorting(nameof(QueryableTestEntity.Property2), SortingSide.Asc),
            secondarySortings: new List<Sorting>
            {
                new(nameof(QueryableTestEntity.Property4), SortingSide.Desc),
                new(nameof(QueryableTestEntity.Property1), SortingSide.Asc),
                new(nameof(QueryableTestEntity.Property3), SortingSide.Asc),
            });

        List<QueryableTestEntity> expectedOrder = EntityList.Entities
            .OrderBy(e => e.Property2)
            .ThenByDescending(e => e.Property4)
            .ThenBy(e => e.Property1)
            .ThenBy(e => e.Property3)
            .ToList();
        List<QueryableTestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
    
    [Fact]
    public async Task RandomPropertyOrderAndRandomSortingSide2_SortedEntities()
    {
        IQueryable<QueryableTestEntity> query = StartQuery.ApplySorting(
            primarySorting: new Sorting(nameof(QueryableTestEntity.Property4), SortingSide.Desc),
            secondarySortings: new List<Sorting>
            {
                new(nameof(QueryableTestEntity.Property2), SortingSide.Asc),
                new(nameof(QueryableTestEntity.Property3), SortingSide.Asc),
                new(nameof(QueryableTestEntity.Property1), SortingSide.Asc),
            });

        List<QueryableTestEntity> expectedOrder = EntityList.Entities
            .OrderByDescending(e => e.Property4)
            .ThenBy(e => e.Property2)
            .ThenBy(e => e.Property3)
            .ThenBy(e => e.Property1)
            .ToList();
        List<QueryableTestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
}