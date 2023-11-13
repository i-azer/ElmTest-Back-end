using Elm.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elm.Cache.InMemory
{
    public static class ServiceRegistration
    {
        public static void AddInMemoryCacheInfrastructure(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheProvider, CacheProvider>();
        }
    }
}
