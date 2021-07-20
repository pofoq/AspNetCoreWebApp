using Microsoft.Extensions.DependencyInjection;
using SecurityLayer.Services;
using SecurityLayer.Abstraction.Services;

namespace SecurityLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddSecurityLayer(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
