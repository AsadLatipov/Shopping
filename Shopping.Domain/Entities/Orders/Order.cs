using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Domain.Entities.Products;
using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Entities.Orders
{
    [Table("orders")]
    public class Order : IAuditable
    {
        [Key]
        [Required]

        public Guid Id { get; set; }
        public DateTime OrderedDate { get; set; } = DateTime.Now;
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int TotalAmount { get; set; }
        public ItemState State { get; set; } = ItemState.created;
    }
}
