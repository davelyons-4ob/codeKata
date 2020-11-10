using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Models;

namespace CheckoutKata.Business.Interfaces
{
    public interface IProductManager
    {
        Task<IQueryable<ProductModel>> GetAllProducts();
    }
}