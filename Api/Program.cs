using Api.Extensions;
using Api.Parameters;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Extensions;
using Infrastructure.ExceptionCatching.ExceptionMappers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddServices();
services.AddRepositories();
services.AddAppDbContext(ParametersProvider.GetConnectionString(configuration));
services.AddDomainModelsIdGenerators();
services.AddExceptionCatcherMiddlewareServicesConfigured();

services.AddControllers()
    .AddXmlDataContractSerializerFormatters();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();