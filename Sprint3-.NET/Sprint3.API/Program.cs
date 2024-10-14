using Sprint3.API.Configuration;
using Sprint3.API.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);
builder.Services.Configure<AppConfiguration>(configuration);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDBContexts(appConfiguration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
