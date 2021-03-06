using FluentValidation;
using kaprekars.constant.data;
using kaprekars.constant.services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton<IRepository, Repository>()
    .AddSingleton<IValidator<Request>, RequestValidator>()
    .AddHealthChecks();

services.AddControllers();
services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapHealthChecks("/health");
app.MapControllers();

await app.RunAsync();
