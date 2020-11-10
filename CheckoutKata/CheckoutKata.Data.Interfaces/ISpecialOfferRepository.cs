using System.Collections.Generic;
using System.Threading.Tasks;
using CheckoutKata.Entities;

namespace CheckoutKata.Data.Interfaces
{
    public interface ISpecialOfferRepository
    {
        Task<List<SpecialOffer>> GetSpecialOffersForProduct(string productSKU);
    }
}