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

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _unitOfWork.Customers.GetByIdAsync(customerId);
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }

        public async Task UpdateCustomerById(Customer upCustomer, int customerId)
        {
            Customer customer = await GetCustomerById(customerId);
            customer.CustomerName = upCustomer.CustomerName;
            customer.CustomerPhone = upCustomer.CustomerPhone;
            customer.CustomerAddress = upCustomer.CustomerAddress;
            customer.MarketId = upCustomer.MarketId;
            customer.UserId = upCustomer.UserId;            
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCustomerById(int customerId)
        {
            Customer customer = await GetCustomerById(customerId);
            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Customer> GetCustomerfromPhone(string phoneNumber)
        {
            return await _unitOfWork.Customers.GetAllQuery().Where(q => q.CustomerPhone == phoneNumber).FirstOrDefaultAsync();
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



    }
}
