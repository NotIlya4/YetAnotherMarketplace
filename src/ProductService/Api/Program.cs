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
services.AddControllers()
    .AddXmlDataContractSerializerFormatters();
services.AddEndpointsApiExplorer();
services.AddConfiguredSwaggerGen();
services.AddConfiguredCors();

var app = builder.Build();

if (parametersProvider.AutoApplyMigrations())
{
    app.ApplyMigrations();
}

app.UseConfiguredCors();
app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();