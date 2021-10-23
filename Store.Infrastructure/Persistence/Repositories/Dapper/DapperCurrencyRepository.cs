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
    public class DapperCurrencyRepository : DapperRepositoryBase, ICurrencyRepository
    {
        readonly IConfigurationSection config;
        public DapperCurrencyRepository(IDbConnection conn, 
            ICurrentUserService userService, 
            ITimestampService timestampService,
            IConfiguration config) : base(conn, userService, timestampService)
        {
            this.config = config.GetSection("CurrencySPVersionControl");
        }

        public async Task<IEnumerable<T>> GetAvailableCurrencies<T>()
        {
            var version = config[nameof(GetAvailableCurrencies)] ?? "";
            return await QuerySP<T>("dbo.spCurrencies_GetAll" + version);
        }
    }
}
