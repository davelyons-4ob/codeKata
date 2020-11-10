using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;

namespace CheckoutKata.Data
{
    public class BasketRepository : IBasketRepository
    {
        public Task AddItemToBasket()
        {
            throw new System.NotImplementedException();
        }

        public Task ClearBasket()
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<BasketItem>> GetBasket()
        {
            throw new System.NotImplementedException();
        }
    }
}