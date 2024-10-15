using Sprint3.API.Configuration;
using Sprint3.API.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args,
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});

IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);
builder.Services.Configure<AppConfiguration>(configuration);

// Adicionando serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddDBContexts(appConfiguration);
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Mapeia para a raiz
    });
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
