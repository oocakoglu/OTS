using OTS.Core;
using OTS.Model;
using OTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OTS.Core.DTOModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OTS.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<CustomerList>> GetCustomerList()
        {
            var query = (from c in _unitOfWork.Customers.GetAllQuery()
                         join u in _unitOfWork.Users.GetAllQuery() on c.UserId equals u.UserId
                         join m in _unitOfWork.Markets.GetAllQuery() on c.MarketId equals m.MarketId
                         select new CustomerList
                         {
                             CustomerId = c.CustomerId,
                             CustomerName = c.CustomerName,
                             CustomerPhone = c.CustomerPhone,
                             UserId = c.UserId,
                             MarketId = c.MarketId,
                             UserName = u.UserName,
                             MarketName = m.MarketName
                         });

            return await query.ToListAsync();
        }


        public async Task UpdateCustomer(Customer customerToBeUpdated, Customer customer)
        {
            customerToBeUpdated.CustomerName = customer.CustomerName;
            customerToBeUpdated.CustomerPhone = customer.CustomerPhone;
            customerToBeUpdated.MarketId = customer.MarketId;
            customerToBeUpdated.UserId = customer.UserId;
            customerToBeUpdated.CustomerAddress = customer.CustomerAddress;
            await _unitOfWork.CommitAsync();
        }

        //Task<IEnumerable<Customer>> ICustomerService.GetAllCustomerWithUserAndMarket()
        //{
        //    return _unitOfWork.Customers.GetAllAsync();
        //    throw new NotImplementedException();
        //}
    }
}
