using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sprint3.API.Configuration;
using Sprint3.Database;
using Sprint3.Repository;
using Sprint3.Service;


namespace Sprint3.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }

        public static IServiceCollection AddDBContexts(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services.AddDbContext<FIAPDBContext>(options =>
            {
                options.UseOracle(appConfiguration.ConnectionStrings.OracleFIAP);
            });
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact
                    {
                        Email = appConfiguration.Swagger.Email,
                        Name = appConfiguration.Swagger.Name
                    }
                });
            });
            return services;
        }
    }
}


