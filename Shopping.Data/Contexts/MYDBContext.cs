using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities.Customers;
using Shopping.Domain.Entities.Orders;
using Shopping.Domain.Entities.Products;
using Shopping.Domain.Entities.Storages;

namespace Shopping.Data.Contexts
{
    public class MYDBContext : DbContext
    {
        public MYDBContext(DbContextOptions<MYDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

    }
}
