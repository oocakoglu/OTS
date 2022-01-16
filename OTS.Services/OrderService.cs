using OTS.Core;
using OTS.Model;
using OTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task DeleteOrder(Order order)
        {
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CommitAsync();     
        }

        public async Task UpdateOrder(Order orderToBeUpdated, Order order)
        {
            orderToBeUpdated.UserId = order.UserId;
            orderToBeUpdated.MarketId = order.MarketId;
            orderToBeUpdated.CustomerId = order.CustomerId;
            orderToBeUpdated.ProductName = order.ProductName;
            orderToBeUpdated.ProductCode = order.ProductCode;
            orderToBeUpdated.Width = order.Width;
            orderToBeUpdated.Length = order.Length;
            orderToBeUpdated.M2 = order.M2;
            orderToBeUpdated.Description = order.Description;
            await _unitOfWork.CommitAsync();
        }
    }
}
