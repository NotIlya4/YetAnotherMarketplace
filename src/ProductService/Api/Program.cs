using Api.Extensions;
using Api.Parameters;
using ExceptionCatcherMiddleware.Extensions;
using Infrastructure.SortingSystem.Parser;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddServices();
services.AddSortingInfoParsers();
services.AddRepositories();
services.AddAppDbContext(ParametersProvider.GetConnectionString(configuration));
services.AddExceptionCatcherMiddlewareServicesConfigured();
services.AddControllers()
    .AddXmlDataContractSerializerFormatters();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.DescribeAllParametersInCamelCase();
});

var app = builder.Build();

app.UpdateDb();

app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();