using System;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IStorageRepository Storage { get; }
        Task SaveChangesAsync();

    }
}
