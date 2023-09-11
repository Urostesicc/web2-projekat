using DatabaseLayer.Repositories.Interfaces.SpecificRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderProductRepository OrderProducts { get; }
        Task<int> SaveChanges();
    }
}
