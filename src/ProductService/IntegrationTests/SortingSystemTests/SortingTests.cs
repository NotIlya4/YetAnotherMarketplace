using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.SortingSystemTests;

public class SortingTests : IClassFixture<SortingDbFixture>
{
    public SortingDbContext DbContext { get; }
    public SortingApplier SortingApplier { get; }
    public TestEntityList EntityList { get; }
    public IQueryable<TestEntity> StartQuery { get; }

    public SortingTests(SortingDbFixture fixture)
    {
        SortingApplier = new SortingApplier(new PropertyReflections());
        EntityList = new TestEntityList();
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
        List<TestEntity> expectedOrder;
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
        
        IQueryable<TestEntity> query = SortingApplier.ApplySorting(
            query: StartQuery, 
            primarySorting: new SortingInfo<TestEntity>(nameof(TestEntity.Property1), sortingSide),
            secondarySortings: new List<SortingInfo<TestEntity>>
            {
                new(nameof(TestEntity.Property2), sortingSide),
                new(nameof(TestEntity.Property3), sortingSide),
                new(nameof(TestEntity.Property4), sortingSide),
            });
        
        List<TestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
    
    [Fact]
    public async Task RandomPropertyOrderAndRandomSortingSide1_SortedEntities()
    {
        IQueryable<TestEntity> query = SortingApplier.ApplySorting(
            query: StartQuery, 
            primarySorting: new SortingInfo<TestEntity>(nameof(TestEntity.Property2), SortingSide.Asc),
            secondarySortings: new List<SortingInfo<TestEntity>>
            {
                new(nameof(TestEntity.Property4), SortingSide.Desc),
                new(nameof(TestEntity.Property1), SortingSide.Asc),
                new(nameof(TestEntity.Property3), SortingSide.Asc),
            });

        List<TestEntity> expectedOrder = EntityList.Entities
            .OrderBy(e => e.Property2)
            .ThenByDescending(e => e.Property4)
            .ThenBy(e => e.Property1)
            .ThenBy(e => e.Property3)
            .ToList();
        List<TestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
    
    [Fact]
    public async Task RandomPropertyOrderAndRandomSortingSide2_SortedEntities()
    {
        IQueryable<TestEntity> query = SortingApplier.ApplySorting(
            query: StartQuery, 
            primarySorting: new SortingInfo<TestEntity>(nameof(TestEntity.Property4), SortingSide.Desc),
            secondarySortings: new List<SortingInfo<TestEntity>>
            {
                new(nameof(TestEntity.Property2), SortingSide.Asc),
                new(nameof(TestEntity.Property3), SortingSide.Asc),
                new(nameof(TestEntity.Property1), SortingSide.Asc),
            });

        List<TestEntity> expectedOrder = EntityList.Entities
            .OrderByDescending(e => e.Property4)
            .ThenBy(e => e.Property2)
            .ThenBy(e => e.Property3)
            .ThenBy(e => e.Property1)
            .ToList();
        List<TestEntity> result = await query.ToListAsync();

        Assert.Equal(expectedOrder, result);
    }
}