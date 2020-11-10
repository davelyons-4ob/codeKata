using System.Collections.Generic;

namespace CheckoutKata.Models
{
    public class BasketModel
    {
        public List<BasketItemModel> Items { get; set; }

        public decimal Total { get; set; }
        
    }
}