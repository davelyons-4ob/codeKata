using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutKata.Models;

namespace CheckoutKata.Business.Interfaces
{
    public interface IProductManager
    {
        Task<List<ProductModel>> GetAllProducts();
    }
}