using OTS.Model;
using OTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OTS.Data.Repositories
{
    public class MarketRepository : Repository<Market>, IMarketRepository
    {
        public MarketRepository(OTSDbContext context) : base(context)
        {
        }

        private OTSDbContext OTSDbContext
        {
            get { return Context as OTSDbContext; }
        }

        //public async Task<IEnumerable<Market>> GetAllWithUserAsync()
        //{
        //    return await OTSDbContext.Markets.Include(q => q.User).ToListAsync();
        //    //return await OTSDbContext.Markets.ToListAsync();
        //}
    }
}
