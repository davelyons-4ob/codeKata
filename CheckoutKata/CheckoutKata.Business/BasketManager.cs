using System.Threading.Tasks;
using CheckoutKata.Business.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata.Business
{
    public class BasketManager : IBasketManager
    {
        public Task AddItemToBasket(string sku)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasketItemModel> GetCurrentBasket()
        {
            throw new System.NotImplementedException();
        }
    }
}