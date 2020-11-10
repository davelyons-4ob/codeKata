using CheckoutKata.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckoutKata.Data
{
    public class CheckoutKataContext : DbContext
    {
        public CheckoutKataContext(DbContextOptions options) : base(options)
        {
            LoadProducts();
            LoadSpecialOffers();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }

        private void LoadProducts()
        {
            Product.Add(new Product
            {
                SKU = "A99",
                Price = 0.50m
            });

            Product.Add(new Product
            {
                SKU = "B15",
                Price = 0.30m
            });

            Product.Add(new Product
            {
                SKU = "C40",
                Price = 0.60m
            });
        }

        private void LoadSpecialOffers()
        {
            SpecialOffers.Add(new SpecialOffer
            {
                SKU = "A99",
                Price = 1.30m,
                Quantity = 3
            });

            SpecialOffers.Add(new SpecialOffer
            {
                SKU = "B15",
                Price = 0.45m,
                Quantity = 2
            });
        }
    }
}