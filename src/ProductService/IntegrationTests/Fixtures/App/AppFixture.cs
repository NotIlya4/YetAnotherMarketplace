using IntegrationTests.Fixtures.Db;

namespace IntegrationTests.Fixtures.App;

public class AppFixture : IClassFixture<DbFixture>, IDisposable
{
    private DbFixture DbFixture { get; }
    
    public AppFixture(DbFixture dbFixture)
    {
        DbFixture = dbFixture;
        
    }

    public void Dispose()
    {
        DbFixture.Dispose();
    }
}