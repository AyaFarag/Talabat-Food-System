using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.Contracts.Services;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Automapper;
using Talabat.Infrastructure.Presistance.Repository;

namespace Talabat.Infrastructure.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddAutoMapper(typeof(UserProfile));
            return services;
        }

        public static WebApplication UseInfrastructureServices(this WebApplication app)
        {


            return app;
        }
    }
}
