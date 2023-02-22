using System.Reflection;
using ConsoleApp1;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Extensions;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionMappers;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollection = new();
serviceCollection.AddExceptionCatcherMiddlewareServices(optionsBuilder =>
{
    optionsBuilder.RegisterExceptionMapper<NoSuchEntityInRepositoryException, NoSuchEntityInRepositoryExceptionMapper>();
});
ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

MappersDispatcher mappersDispatcher = serviceProvider.GetRequiredService<MappersDispatcher>();

BadResponse badResponse = mappersDispatcher.Map(new Exception("aaa"));

bool a = true;
bool b = a;