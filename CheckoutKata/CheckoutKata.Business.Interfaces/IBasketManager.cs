using System.Threading.Tasks;
using CheckoutKata.Models;

namespace CheckoutKata.Business.Interfaces
{
    public interface IBasketManager
    {
        Task AddItemToBasket(string sku);
        Task<BasketModel> GetCurrentBasket();
    }
}