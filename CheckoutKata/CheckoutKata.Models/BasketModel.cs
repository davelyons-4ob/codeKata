using System.Collections.Generic;

namespace CheckoutKata.Models
{
    public class BasketModel
    {
        public BasketModel()
        {
            Items = new List<BasketItemModel>();
            Total = 0.00m;
        }

        public List<BasketItemModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}