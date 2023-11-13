// Ignore Spelling: Orm

using Elm.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elm.Dapper.Orm
{
    public static class ServiceRegistration
    {
        public static void AddDapperInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
