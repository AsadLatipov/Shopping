using System;

namespace Shopping.Service.ViewModels.Products
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public DateTime AdoptedDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; }
        public int Count { get; set; }
    }
}
