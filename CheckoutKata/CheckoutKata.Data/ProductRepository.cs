using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckoutKata.Data
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(CheckoutKataContext db) : base(db)
        {
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Product.ToListAsync();
        }
    }
}