using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutKata.Business;
using CheckoutKata.Business.Interfaces;
using CheckoutKata.Common.Exceptions;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;
using CheckoutKata.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class BasketTests
    {
        private readonly List<BasketItem> basketItems = new List<BasketItem>();
        private readonly List<ProductModel> productList = new List<ProductModel>();

        [SetUp]
        public void Setup()
        {
            #region productList

            productList.Add(new ProductModel
            {
                Price = 0.50m,
                ProductId = Guid.NewGuid(),
                SKU = "A99"
            });

            productList.Add(new ProductModel
            {
                Price = 0.30m,
                ProductId = Guid.NewGuid(),
                SKU = "B15"
            });

            productList.Add(new ProductModel
            {
                Price = 0.60m,
                ProductId = Guid.NewGuid(),
                SKU = "C40"
            });

            #endregion

            #region products

            var product1 = new Product
            {
                Price = 0.50m,
                ProductId = Guid.NewGuid(),
                SKU = "A99"
            };

            var product2 = new Product
            {
                Price = 0.30m,
                ProductId = Guid.NewGuid(),
                SKU = "B15"
            };

            var product3 = new Product
            {
                Price = 0.60m,
                ProductId = Guid.NewGuid(),
                SKU = "C40"
            };

            #endregion

            basketItems.Add(new BasketItem
            {
                Product = product1,
                BasketItemId = Guid.NewGuid(),
                ProductId = product1.ProductId
            });

            basketItems.Add(new BasketItem
            {
                Product = product1,
                BasketItemId = Guid.NewGuid(),
                ProductId = product1.ProductId
            });

            basketItems.Add(new BasketItem
            {
                Product = product2,
                BasketItemId = Guid.NewGuid(),
                ProductId = product2.ProductId
            });

            basketItems.Add(new BasketItem
            {
                Product = product2,
                BasketItemId = Guid.NewGuid(),
                ProductId = product2.ProductId
            });

            basketItems.Add(new BasketItem
            {
                Product = product2,
                BasketItemId = Guid.NewGuid(),
                ProductId = product2.ProductId
            });
        }

        [Test]
        public async Task Adding_an_item_to_a_basket_with_a_valid_product_code_works_correctly()
        {
            var mockProductManager = new Mock<IProductManager>();
            var basketRepository = new Mock<IBasketRepository>();
            var specialOfferRepository = new Mock<ISpecialOfferRepository>();

            mockProductManager.Setup(x => x.GetAllProducts()).ReturnsAsync(() => productList);
            basketRepository.Setup(x => x.AddItemToBasket(It.IsAny<BasketItem>()));

            var basketManager = new BasketManager(mockProductManager.Object, basketRepository.Object,
                specialOfferRepository.Object);

            Func<Task> action = async () => { await basketManager.AddItemToBasket("A99"); };

            action.Should().NotThrow<ProductNotFoundException>();
        }

        [Test]
        public void Adding_an_item_to_a_basket_with_an_invalid_product_code_should_throw_exception()
        {
            var mockProductManager = new Mock<IProductManager>();
            var basketRepository = new Mock<IBasketRepository>();
            var specialOfferRepository = new Mock<ISpecialOfferRepository>();

            mockProductManager.Setup(x => x.GetAllProducts()).ReturnsAsync(() => productList);
            basketRepository.Setup(x => x.AddItemToBasket(It.IsAny<BasketItem>()));

            var basketManager = new BasketManager(mockProductManager.Object, basketRepository.Object,
                specialOfferRepository.Object);

            Action act = async () => await basketManager.AddItemToBasket("F123");

            act.Should().Throw<ProductNotFoundException>();
        }

        [Test]
        public async Task Retrieving_A_Basket_Should_Apply_Special_Offers()
        {
            var mockProductManager = new Mock<IProductManager>();
            var basketRepository = new Mock<IBasketRepository>();
            var specialOfferRepository = new Mock<ISpecialOfferRepository>();

            mockProductManager.Setup(x => x.GetAllProducts()).ReturnsAsync(() => productList);
            basketRepository.Setup(x => x.GetBasket()).ReturnsAsync(() => basketItems);
            specialOfferRepository.Setup(x => x.GetSpecialOffersForProduct("B15")).ReturnsAsync(() =>
                new List<SpecialOffer>
                {
                    new SpecialOffer
                    {
                        Price = 0.45m,
                        Quantity = 2,
                        SKU = "B15"
                    }
                });
            specialOfferRepository.Setup(x => x.GetSpecialOffersForProduct("A99")).ReturnsAsync(() =>
                new List<SpecialOffer>());
            var basketManager = new BasketManager(mockProductManager.Object, basketRepository.Object,
                specialOfferRepository.Object);

            var result = await basketManager.GetCurrentBasket();

            //Two different distinct item types. (2 A99's, 3 B15's)
            result.Items.Count.Should().Be(2);
            result.Total.Should().Be(1.75m);
            //0.50 + 0.50 + 0.45 (2 products discounted) + 0.30
        }
    }
}