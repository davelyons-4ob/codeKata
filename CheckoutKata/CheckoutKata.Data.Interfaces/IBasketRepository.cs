using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Entities;

namespace CheckoutKata.Data.Interfaces
{
    public interface IBasketRepository
    {
        Task AddItemToBasket();

        Task ClearBasket();

        Task<IQueryable<BasketItem>> GetBasket();
    }
}