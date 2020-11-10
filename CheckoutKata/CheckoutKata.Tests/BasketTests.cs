using System;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Business;
using CheckoutKata.Common.Exceptions;
using CheckoutKata.Data.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class BasketTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Adding_an_item_to_a_basket_with_a_valid_product_code_works_correctly()
        {
            var basketManager = new BasketManager();

            Action act = async () => await basketManager.AddItemToBasket("A99");

            act.Should().NotThrow<ProductNotFoundException>();

            var basket = await basketManager.GetCurrentBasket();
            
            basket.Items.Count.Should().Be(1);
            basket.Items.Single().SKU.Should().Be("A99");
        }
        
        [Test]
        public async Task Adding_an_item_to_a_basket_with_an_invalid_product_code_should_throw_exception()
        {
            var basketManager = new BasketManager();

            Action act = async () => await basketManager.AddItemToBasket("F123");

            act.Should().Throw<ProductNotFoundException>();
        }
    }
}