namespace CheckoutKata.Models
{
    public class BasketItemModel
    {
        public int Quantity { get; set; }
        public string SKU { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}