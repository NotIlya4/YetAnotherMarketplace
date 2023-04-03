using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace IntegrationTests.Fixture;

[CollectionDefinition(nameof(AppFixture))]
public class AppFixture : ICollectionFixture<AppFixture>, IAsyncDisposable
{
    internal WebApplicationFactory<Program> WebApplicationFactory { get; }
    public HttpClient Client { get; }
    private IDatabase Redis { get; }

    public AppFixture()
    {
        WebApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("IntegrationTests");
        });
        Client = WebApplicationFactory.CreateClient();
        Redis = WebApplicationFactory.Services.GetRequiredService<IConnectionMultiplexer>().GetDatabase();
    }

    public async Task FlushDb()
    {
        await Redis.ExecuteAsync("FLUSHDB");
    }

    public async ValueTask DisposeAsync()
    {
        await FlushDb();
    }
}