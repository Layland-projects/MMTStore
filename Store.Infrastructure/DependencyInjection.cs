using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Persistence.Repositories.Dapper;
using Store.Infrastructure.Persistence.Repositories.Interfaces;
using Store.Infrastructure.Services;
using Store.Infrastructure.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITimestampService, TimestampService>();
            services.AddScoped<IProductRepository, DapperProductRepository>();
            services.AddScoped<IProductCategoryRepository, DapperProductCategoryRepository>();
            services.AddScoped<ICurrencyRepository, DapperCurrencyRepository>();
            services.AddScoped<IFeaturedProductCategoryRepository, DapperFeaturedProductCategoryRepository>();
            services.AddScoped<IDbConnection>(x =>
                new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
