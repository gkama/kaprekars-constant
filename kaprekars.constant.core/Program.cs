using kaprekars.constant.services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton<IRepository, Repository>()
    .AddHealthChecks();

services.AddControllers();
services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.MapHealthChecks("/health");
app.MapControllers();

await app.RunAsync();
