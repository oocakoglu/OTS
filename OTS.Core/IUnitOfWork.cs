using OTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICargoRepository Cargos { get;  }
        ICustomerRepository Customers { get; }
        IMarketRepository Markets { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();

    }
}
