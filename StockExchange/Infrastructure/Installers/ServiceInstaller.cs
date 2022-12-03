
using StockExchange.API.Services;
using StockExchange.Domain.UserAggregate;
using StockExchange.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchange.API.Infrastructure.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StockExchange.API", Version = "v1" });
            });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
