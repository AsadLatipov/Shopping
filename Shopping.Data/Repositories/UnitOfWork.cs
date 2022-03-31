using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace Shopping.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MYDBContext context;
        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IProductRepository Products { get; private set; }

        public IStorageRepository Storage { get; private set; }

        public UnitOfWork(MYDBContext context)
        {
            this.context = context;
            Customers = new CustomerRepository(context);
            Orders = new OrderRepository(context);
            Products = new ProductRepository(context);
            Storage = new StorageRepository(context);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
