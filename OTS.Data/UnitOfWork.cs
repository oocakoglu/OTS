using OTS.Core;
using OTS.Core.Repositories;
using OTS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OTSDbContext _context;

        private CargoRepository _cargoRepository;

        private CustomerRepository _customerRepository;

        private MarketRepository _marketRepository;

        private OrderRepository _orderRepository;

        private UserRepository _userRepository;
        
        public UnitOfWork(OTSDbContext context)
        {
            this._context = context;
        }


        public ICargoRepository Cargos => _cargoRepository = _cargoRepository ?? new CargoRepository(_context);

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public IMarketRepository Markets => _marketRepository = _marketRepository ?? new MarketRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);


        public async Task<int> CommitAsync()
        {
            //try
            //{
                return await _context.SaveChangesAsync();
            //}
            //catch (Exception e)
            //{
            //    ;
            //    return await _context.SaveChangesAsync();
            //}

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
