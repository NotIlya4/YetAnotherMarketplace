using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceProviderExtensions
{
    public static async Task UsingScope(this IServiceProvider services, Func<IServiceProvider, Task> lambda)
    {
        AsyncServiceScope scope = services.CreateAsyncScope();
        await lambda(scope.ServiceProvider);
        await scope.DisposeAsync();
    }
    
    public static async Task UsingScope<TService>(this IServiceProvider services, Func<TService, Task> lambda) where TService : notnull
    {
        AsyncServiceScope scope = services.CreateAsyncScope();
        TService service = scope.ServiceProvider.GetRequiredService<TService>();
        await lambda(service);
        await scope.DisposeAsync();
    }
}