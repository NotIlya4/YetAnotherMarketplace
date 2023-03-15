using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;
ParametersProvider parametersProvider = new ParametersProvider(configuration);

services.AddServices();
services.AddSortingInfoParsers();
services.AddPropertyLambdaBuilders();
services.AddSortingAppliers();
services.AddRepositories();
services.AddAppDbContext(parametersProvider.GetConnectionString());
services.AddExceptionCatcherMiddlewareServicesConfigured();
services.AddControllers()
    .AddXmlDataContractSerializerFormatters();
services.AddEndpointsApiExplorer();
services.AddConfiguredSwaggerGen();


var app = builder.Build();

if (parametersProvider.IsAutoMigrationsApply())
{
    app.UpdateDb();
}

app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();