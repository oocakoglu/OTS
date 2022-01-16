using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order newOrder);
        Task UpdateOrder(Order orderToBeUpdated, Order order);
        Task DeleteOrder(Order order);
    }
}
