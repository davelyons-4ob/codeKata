using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Business.Interfaces;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata.Business
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();

            return result.Select(p => new ProductModel
            {
                Price = p.Price,
                ProductId = p.ProductId,
                SKU = p.SKU
            }).ToList();
        }
    }
}