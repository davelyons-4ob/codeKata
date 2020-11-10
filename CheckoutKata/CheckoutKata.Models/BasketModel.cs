using System.Collections.Generic;

namespace CheckoutKata.Models
{
    public class BasketModel
    {
        public List<BasketItemModel> Type { get; set; }

        public decimal Total { get; set; }
        
    }
}