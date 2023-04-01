using IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

[Collection(nameof(AppFixture))]
public class Testss
{
    internal WebApplicationFactory<Program> WebApplicationFactory { get; }
    
    public Testss(AppFixture appFixture)
    {
        WebApplicationFactory = appFixture.WebApplicationFactory;
    }
}