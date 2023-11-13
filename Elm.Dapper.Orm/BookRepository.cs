// Ignore Spelling: Orm

using Dapper;
using Elm.Application.Contracts.Services;
using Elm.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Elm.Dapper.Orm
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;
        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Book>> GetBooks(int offset, int limit,string slug)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                        var sql = @$"select DataGramsResult.* from 
            (select * FROM dbo.Book WHERE FREETEXT(BookInfo,'{slug}')) 
            DataGramsResult
            order by LastModified Desc
            OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY";
            var books = await connection.QueryAsync<Book>(sql);
            return books;
        }
    }
}