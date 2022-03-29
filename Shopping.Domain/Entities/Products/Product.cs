using Shopping.Domain.Commons;
using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Entities.Products
{
    [Table("products")]
    public class Product : IAuditable
    {
        [Key]
        [Required]

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public DateTime AdoptedDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; }
        public ItemState State { get; set; } = ItemState.created;
    }
}
