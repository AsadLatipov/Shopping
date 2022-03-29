using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Products;
using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Entities.Storages
{
    [Table("storages")]
    public class Storage : IAuditable
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public long TotalCount { get; set; }
        public ItemState State { get; set; } = ItemState.created;
    }
}
