using Application;
using Infrastructure;
namespace Inventory_Management_System
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                   .AddInfDI();
            return services;

        }
    }
}
