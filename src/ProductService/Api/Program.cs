using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ParametersProvider parametersProvider = new(builder.Configuration);

services.AddServices();
services.AddSingleton(parametersProvider);
services.AddRepositories();
services.AddMappers();
services.AddAppDbContext(parametersProvider.GetConnectionString());
services.AddExceptionCatcherMiddlewareServicesConfigured();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddConfiguredSwaggerGen();
services.AddConfiguredCors();

var app = builder.Build();

await app.MigrationsAndSeeding(parametersProvider);

app.UseExceptionCatcherMiddleware();
app.UseConfiguredCors();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();