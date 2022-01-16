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
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer customer);

        Task<IEnumerable<CustomerList>> GetCustomerList();
    }
}
