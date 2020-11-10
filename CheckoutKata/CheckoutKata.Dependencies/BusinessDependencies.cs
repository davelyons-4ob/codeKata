using CheckoutKata.Business;
using CheckoutKata.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CheckoutKata.Dependencies
{
    public static class BusinessDependencies
    {
        public static void AddBusinessDependencies(this IServiceCollection service)
        {
            service.AddScoped<IBasketManager, BasketManager>();
            service.AddScoped<IProductManager, ProductManager>();
        }
    }
}