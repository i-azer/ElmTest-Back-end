using Elm.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elm.Application
{
    public static class ServiceRegistration
    {
        public static void AddElmApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ISearchApplicationService, SearchApplicationService>();
        }
    }
}
