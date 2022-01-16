using OTS.Model;
using OTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OTSDbContext context) : base(context)
        {
        }
    }
}
