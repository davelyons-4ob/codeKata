using System;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Business.Interfaces;
using CheckoutKata.Common.Exceptions;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;
using CheckoutKata.Models;

namespace CheckoutKata.Business
{
    public class BasketManager : IBasketManager
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductManager _productManager;
        private readonly ISpecialOfferRepository _specialOfferRepository;

        public BasketManager(IProductManager productManager, IBasketRepository basketRepository,
                             ISpecialOfferRepository specialOfferRepository)
        {
            _productManager = productManager;
            _basketRepository = basketRepository;
            _specialOfferRepository = specialOfferRepository;
        }

        public async Task AddItemToBasket(string sku)
        {
            var products = await _productManager.GetAllProducts();

            if (!products.Any(p => string.Equals(p.SKU, sku, StringComparison.CurrentCultureIgnoreCase)))
                throw new ProductNotFoundException("Provided Product does not exist");

            var theProduct = products.Single(p => string.Equals(p.SKU, sku, StringComparison.CurrentCultureIgnoreCase));

            await _basketRepository.AddItemToBasket(new BasketItem
            {
                ProductId = theProduct.ProductId
            });
        }

        public async Task<BasketModel> GetCurrentBasket()
        {
            var items = await _basketRepository.GetBasket();
            var myBasket = new BasketModel();

            foreach (var basketItem in items)
            {
                var existingBasketItem = myBasket.Items.SingleOrDefault(bi => bi.SKU == basketItem.Product.SKU);
                var specialOffersForProduct =
                    await _specialOfferRepository.GetSpecialOffersForProduct(basketItem.Product.SKU);

                if (existingBasketItem != null)
                {
                    existingBasketItem.Quantity++;

                    if (!specialOffersForProduct.Any())
                    {
                        existingBasketItem.Total = existingBasketItem.Quantity * existingBasketItem.UnitPrice;
                    }
                    else
                    {
                        //Only accepting one special offer per product per basket
                        var theSpecialOffer = specialOffersForProduct.First();

                        var quantityOfSpecialOffers = existingBasketItem.Quantity / theSpecialOffer.Quantity;
                        var itemsInSpecialOffer = quantityOfSpecialOffers * theSpecialOffer.Quantity;
                        var itemsNotInSpecialOffer = existingBasketItem.Quantity - itemsInSpecialOffer;

                        existingBasketItem.Total = quantityOfSpecialOffers * theSpecialOffer.Price +
                                                   itemsNotInSpecialOffer * existingBasketItem.UnitPrice;
                    }
                }
                else
                {
                    myBasket.Items.Add(new BasketItemModel
                    {
                        Quantity = 1,
                        Total = basketItem.Product.Price,
                        UnitPrice = basketItem.Product.Price,
                        SKU = basketItem.Product.SKU
                    });
                }
            }

            myBasket.Total = myBasket.Items.Sum(bi => bi.Total);

            return myBasket;
        }
    }
}