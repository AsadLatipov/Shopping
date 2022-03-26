using Shopping.Domain.Commons;
using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Domain.Entities.Customers
{
    public class Customer : IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ItemState State { get; set; } = ItemState.created;
    }
}
