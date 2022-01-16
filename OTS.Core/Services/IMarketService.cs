using OTS.Core.DTOModels;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface IMarketService
    {
        Task<Market> GetMarketById(int id);
        Task<Market> CreateMarket(Market newMarket);
        Task UpdateMarketWithId(Market upMarket, int marketId);
        Task DeleteMarketWithId(int marketId);
        Task<IEnumerable<Market>> GetAllMarket();
        Task<IEnumerable<MarketList>> GetAllMarketWithUser();       

    }
}
