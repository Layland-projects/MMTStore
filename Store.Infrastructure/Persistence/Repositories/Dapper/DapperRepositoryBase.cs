using Dapper;
using Store.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Dapper
{
    public abstract class DapperRepositoryBase : IDisposable
    {
        private readonly IDbConnection _conn;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITimestampService _timestampService;
        public DapperRepositoryBase(IDbConnection conn,
            ICurrentUserService userService,
            ITimestampService timestampService)
        {
            _conn = conn;
            _currentUserService = userService;
            _timestampService = timestampService;
        }

        public void Dispose()
        {
            _conn.Dispose();
        }

        protected async Task<IEnumerable<T>> QuerySP<T>(string spName, object args = null) =>
            await _conn.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args);
        protected async Task<IEnumerable<T3>> QuerySP<T1, T2, T3>(string spName, Func<T1, T2, T3> map, object args = null, string splitOn = "Id") =>
            await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn);
        protected async Task<IEnumerable<T4>> QuerySP<T1, T2, T3, T4>(string spName, Func<T1, T2, T3, T4> map, object args = null, string splitOn = "Id") =>
            await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn);
        protected async Task<IEnumerable<T5>> QuerySP<T1, T2, T3, T4, T5>(string spName, Func<T1, T2, T3, T4, T5> map, object args = null, string splitOn = "Id") =>
            await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn);
        protected async Task<T> QuerySPSingle<T>(string spName, object args = null) =>
            (await QuerySP<T>(spName, args)).FirstOrDefault();
        protected async Task<T3> QuerySPSingle<T1, T2, T3>(string spName, Func<T1, T2, T3> map, object args = null, string splitOn = "Id") =>
            (await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn)).FirstOrDefault();
        protected async Task<T4> QuerySPSingle<T1, T2, T3, T4>(string spName, Func<T1, T2, T3, T4> map, object args = null, string splitOn = "Id") =>
            (await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn)).FirstOrDefault();
        protected async Task<T5> QuerySPSingle<T1, T2, T3, T4, T5>(string spName, Func<T1, T2, T3, T4, T5> map, object args = null, string splitOn = "Id") =>
            (await _conn.QueryAsync(spName, map, commandType: CommandType.StoredProcedure, commandTimeout: 300, param: args, splitOn: splitOn)).FirstOrDefault();
        protected async Task<int> InsertSP(string spName, DataTable dt, string username = "Unknown")
        {
            var p = new DynamicParameters();
            p.Add("@timestamp", _timestampService.UtcNow.UtcDateTime, DbType.DateTime2);
            p.Add("@username", username ?? _currentUserService.Username, DbType.String);
            p.Add("@data", dt.AsTableValuedParameter(dt.TableName), DbType.Object);
            return await _conn.ExecuteAsync(spName, param: p, commandType: CommandType.StoredProcedure);
        }
    }
}
