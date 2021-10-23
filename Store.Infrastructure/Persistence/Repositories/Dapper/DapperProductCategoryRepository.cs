using Microsoft.Extensions.Configuration;
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
    public class DapperProductCategoryRepository : DapperRepositoryBase, IProductCategoryRepository
    {
        private readonly IConfigurationSection config;
        public DapperProductCategoryRepository(IDbConnection conn,
            ICurrentUserService userService,
            ITimestampService timestampService,
            IConfiguration config) : base(conn, userService, timestampService) { this.config = config.GetSection("ProductCategoriesSPVersionControl"); }

        public async Task<IEnumerable<T>> GetProductCategories<T>()
        {
            var version = config[nameof(GetProductCategories)] ?? "";
            return await QuerySP<T>("dbo.sp_ProductCategories_GetAll" + version);
        }

        public async Task<T> GetProductCategory<T>(int id)
        {
            var version = config[nameof(GetProductCategory) + "Id"] ?? "";
            return await QuerySPSingle<T>("dbo.sp_ProductCategories_GetById", new { id });
        }

        public async Task<T> GetProductCategory<T>(string name)
        {
            var version = config[nameof(GetProductCategory) + "_Name"] ?? "";
            return await QuerySPSingle<T>("dbo.sp_ProductCategories_GetByName", new { name });
        }
    }
}
