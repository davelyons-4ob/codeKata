using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Data.Interfaces;
using CheckoutKata.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckoutKata.Data
{
    public class SpecialOfferRepository : BaseRepository, ISpecialOfferRepository
    {
        protected SpecialOfferRepository(CheckoutKataContext db) : base(db)
        {
        }

        public async Task<List<SpecialOffer>> GetSpecialOffersForProduct(string productSku)
        {
            var result = _db.SpecialOffers.Where(p => p.SKU.ToUpper() == productSku.ToUpper());

            return await result.ToListAsync();
        }
    }
}