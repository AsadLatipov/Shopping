using System;

namespace Shopping.Service.ViewModels.Orders
{
    public class OrderCreateViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int TotalAmount { get; set; }

    }
}
