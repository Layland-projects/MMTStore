using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Run(IDbConnection conn)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                var sqlFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(SeedData)).Location), "Persistence\\Scripts"));

                foreach(var file in sqlFiles.OrderByDescending(x => x))
                {
                    var t = File.ReadAllText(file);
                    foreach(var block in t.Split("Go"))
                    {
                        conn.Execute(block);
                    }
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}
