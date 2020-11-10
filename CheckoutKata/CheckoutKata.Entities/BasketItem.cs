using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckoutKata.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BasketItemId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")] public Product Product { get; set; }
    }
}