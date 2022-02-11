using BusinessLayer.Services;
using BusinessLayer.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddTransient<IKittenService, KittenService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
