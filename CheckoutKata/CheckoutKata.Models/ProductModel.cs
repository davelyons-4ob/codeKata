using System;

namespace CheckoutKata.Models
{
    public class ProductModel
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
    }
}