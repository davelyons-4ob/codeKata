using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckoutKata.Entities
{
    public class SpecialOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SpecialOfferId { get; set; }
        public string SKU { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}