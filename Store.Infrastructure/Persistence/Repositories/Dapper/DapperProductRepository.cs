using Dapper;
using Microsoft.Extensions.Configuration;
using Store.Core.Domain;
using Store.Infrastructure.Persistence.Repositories.Interfaces;
using Store.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Dapper
{
    public class DapperProductRepository : DapperRepositoryBase, IProductRepository, IDisposable
    {
        readonly IConfigurationSection config;
        public DapperProductRepository(IDbConnection connection,
            ICurrentUserService userService,
            ITimestampService timestampService,
            IConfiguration config) : base(connection, userService, timestampService) { this.config = config.GetSection("ProductSPVersionControl"); }

        public async Task<IEnumerable<T>> GetFeaturedProducts<T>() where T : ProductBase
        {
            var version = config[nameof(GetFeaturedProducts)] ?? "";
            return await QuerySP<T>("dbo.sp_Products_GetFeaturedProducts" + version);
        }

        public async Task<T> GetProduct<T>(int id) where T : ProductBase
        {
            var version = config[nameof(GetProduct)] ?? "";
            return await QuerySPSingle<T>("dbo.sp_Products_GetProduct" + version, new { id });
        }

        public async Task<IEnumerable<T>> GetProducts<T>() where T : ProductBase
        {
            var version = config[nameof(GetProducts)] ?? "";
            return await QuerySP<T>("dbo.sp_Products_GetProducts" + version);
        }

        public async Task<IEnumerable<T>> GetProductsByCategory<T>(int categoryId) where T : ProductBase
        {
            var version = config[nameof(GetProductsByCategory) + "_Id"] ?? "";
            return await QuerySP<T>("dbo.sp_Products_GetProductsByCategoryId" + version, new { categoryId });
        }

        public async Task<IEnumerable<T>> GetProductsByCategory<T>(string categoryName) where T : ProductBase
        {
            var version = config[nameof(GetProduct) + "_Name"] ?? "";
            return await QuerySP<T>("dbo.sp_Products_GetProductsByCategoryName" + version, new { categoryName });
        }
    }
}
