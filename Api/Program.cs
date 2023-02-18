using Api.Extensions;
using Api.Parameters;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddServices();
services.AddRepositories();
services.AddAppDbContext(ParametersProvider.GetConnectionString(configuration));
services.AddDomainModelsIdGenerators();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();