using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutKata.Entities;

namespace CheckoutKata.Data.Interfaces
{
    public interface IBasketRepository
    {
        Task AddItemToBasket(BasketItem basketItem);

        Task ClearBasket();

        Task<List<BasketItem>> GetBasket();
    }
}