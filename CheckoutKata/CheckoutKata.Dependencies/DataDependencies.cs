using CheckoutKata.Data;
using CheckoutKata.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CheckoutKata.Dependencies
{
    public static class DataDependencies
    {
        public static void AddDataDependencies(this IServiceCollection service)
        {
            service.AddScoped<IBasketRepository, BasketRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ISpecialOfferRepository, SpecialOfferRepository>();
        }
    }
}