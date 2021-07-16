using Microsoft.Extensions.DependencyInjection;
using DataLayer.Repositories;
using DataLayer.Abstraction.Repositories;

namespace DataLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            return services.AddTransient<IKittenRepository, KittenRepository>();
        }
    }
}
