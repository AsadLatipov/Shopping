using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Products;
using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Entities.Storages
{
    public class Storage : IAuditable
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public long TotalCount { get; set; }
        public ItemState State { get; set; } = ItemState.created;
    }
}
