using Microsoft.Extensions.DependencyInjection;
using DataLayer.Repositories;
using DataLayer.Abstraction.Repositories;

namespace DataLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddTransient<IKittenRepository, KittenRepository>();
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
