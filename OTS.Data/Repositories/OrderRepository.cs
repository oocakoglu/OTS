using OTS.Model;
using OTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OTSDbContext context) : base(context)
        {
        }
    }
}
