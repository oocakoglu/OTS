using OTS.Core.DTOModels;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomerById(Customer upCustomer, int customerId);
        Task DeleteCustomerById(int customerId);
        
        Task<IEnumerable<CustomerList>> GetCustomerList();
        Task<Customer> GetCustomerfromPhone(string phoneNumber);
    }
}
