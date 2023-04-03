using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;
using Infrastructure.Mappers.BasketEntity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ParametersProvider parameters = new(builder.Configuration);

services.AddControllers();
services.AddRepositories();
services.AddScoped<BasketViewMapper>();
services.AddExceptionMappers();
services.AddRedis(parameters.GetRedisConnectionString());
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
