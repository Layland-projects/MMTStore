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
    public class DapperFeaturedProductCategoryRepository : DapperRepositoryBase, IFeaturedProductCategoryRepository
    {
        readonly IConfigurationSection config;
        public DapperFeaturedProductCategoryRepository(IDbConnection conn, 
            ICurrentUserService userService, 
            ITimestampService timestampService,
            IConfiguration config) : base(conn, userService, timestampService)
        {
            this.config = config.GetSection("FeaturedProductCategorySPVersionControl");
        }

        public async Task<int> CreateNewFeaturedProductCategory<T>(T newObj) where T : FeaturedProductCategory
        {
            var version = config[nameof(CreateNewFeaturedProductCategory)] ?? "";
            var dt = new DataTable("type_FeaturedProductCreate");
            dt.Columns.Add(nameof(newObj.CategoryId), newObj.CategoryId.GetType());
            dt.Columns.Add(nameof(newObj.ValidFrom), typeof(DateTime));
            dt.Columns.Add(nameof(newObj.ValidUntil), typeof(DateTime));
            dt.Rows.Add(newObj.CategoryId, newObj.ValidFrom.UtcDateTime, newObj.ValidUntil.HasValue ? newObj.ValidUntil.Value.UtcDateTime : null);
            return await InsertSP("dbo.sp_FeaturedProductCategories_Add" + version, dt);
        }
    }
}
