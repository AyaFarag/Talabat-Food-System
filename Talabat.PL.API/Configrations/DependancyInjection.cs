using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.Contracts.Services;
using Talabat.Application.Extentions;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Models;
using Talabat.Infrastructure.Presistance.Data;
using Talabat.Infrastructure.Presistance.Repository;

namespace Talabat.PL.API.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                // 1. API General Info
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Talabat System",
                    Description = "This system for food delivery",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Aya Farag",
                        Email = "contact@example.com",
                        Url = new Uri("https://yourwebsite.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under XYZ",
                        Url = new Uri("https://example.com/license")
                    }
                });



                // 3. (Optional) Customize Schema IDs (advanced, usually for big projects)
                //  options.CustomSchemaIds(type => type.FullName);

                // 4. (Optional) Add Authorization Support
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter a valid JWT token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
            });
            return services;
        }
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));



            return services;
        }

        public static WebApplication UseAPIServices(this WebApplication app)
        {


            return app;
        }
    }
}
