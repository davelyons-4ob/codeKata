using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckoutKata.Data
{
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(CheckoutKataContext db) : base(db)
        {
        }

        public async Task AddItemToBasket(BasketItem basketItem)
        {
            await _db.BasketItems.AddAsync(basketItem);

            await _db.SaveChangesAsync();
        }

        public async Task ClearBasket()
        {
            _db.BasketItems.RemoveRange(_db.BasketItems.ToList());

            await _db.SaveChangesAsync();
        }

        public async Task<List<BasketItem>> GetBasket()
        {
            return await _db.BasketItems.ToListAsync();
        }
    }
}