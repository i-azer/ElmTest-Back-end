using Dapper;
using DbUp.Engine;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Migrations.Scripts
{
    internal class S202307131111_Add_Full_Text_Idx : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            using var command = (dbCommandFactory() as SqlCommand)!;

            const string sql = @"CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;
CREATE FULLTEXT INDEX ON [dbo].[Book](BookInfo) KEY INDEX PK_Book;";
            command.Connection.Execute(sql);
            return "";
        }
    }
}
