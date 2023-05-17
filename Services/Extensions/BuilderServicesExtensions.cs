
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.BAL.Configuration;
using Services.BAL.Services;
using Services.DAL;
using System.Diagnostics;

namespace Services.Extensions;

public static class BuilderServicesExtensions
{
    const string connectionEnvironmentVariableName = "CONNECTIONS_STRING";

    public static void AddAuthenticationExtension(this IServiceCollection services, string defaultScheme)
    {
        services.AddAuthentication(defaultScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
    }

    public static void AddDbContextScoped(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options
                .UseNpgsql(connectionString,
                    assembly =>
                        assembly.MigrationsAssembly("Services.DAL.Migrations"));
        });
    }

    public static void AddSwaggerGenWithOptions(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."

            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                         new string[] {}
                    }
                });
        });
    }

    public static void AddRepositoriesScoped(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IDbRepository, DbRepository>();
    }

    public static void AddServicesScoped(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthService, AuthService>();
    }
}
