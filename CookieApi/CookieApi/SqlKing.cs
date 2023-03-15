using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CookieApi
{
    public class SqlKing
    {
        public string ConnectionString { get; set; }
        public SqlKing(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<CookieModel> GetUser(string userName)
        {
            var data = new CookieModel();
            var query = $"select top(1) * from [GETDb].[dbo].[CookieData] where UserName = '{userName}'";

            using (var connection = new SqlConnection(ConnectionString))
            {
               //await connection.OpenAsync();
                data = connection.QueryFirst<CookieModel>(query);
            }

            return data;
        }
    }
}
