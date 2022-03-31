using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace Shopping.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MYDBContext Context;
        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IProductRepository Products { get; private set; }

        public IStorageRepository Storage { get; private set; }

        public UnitOfWork(MYDBContext context)
        {
            Context = context;
            Customers = new CustomerRepository(Context);
            Orders = new OrderRepository(Context);
            Products = new ProductRepository(Context);
            Storage = new StorageRepository(Context);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}
