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
    public class MarketService : IMarketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarketService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Market> GetMarketById(int id)
        {
            return await _unitOfWork.Markets.GetByIdAsync(id);
        }

        public async Task<Market> CreateMarket(Market newMarket)
        {
            await _unitOfWork.Markets.AddAsync(newMarket);
            await _unitOfWork.CommitAsync();
            return newMarket;
        }

        public async Task DeleteMarketWithId(int marketId)
        {
            Market market = await GetMarketById(marketId);
            _unitOfWork.Markets.Remove(market);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateMarketWithId(Market upMarket, int marketId)
        {
            Market market = await GetMarketById(marketId);
            market.UserId = upMarket.UserId;
            market.MarketName = upMarket.MarketName;
            market.Commision = upMarket.Commision;
            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<MarketList>> GetAllMarketWithUser()
        {
            var query = (from m in _unitOfWork.Markets.GetAllQuery()
                         join u in _unitOfWork.Users.GetAllQuery()
                             on m.UserId equals u.UserId
                         select new MarketList
                         {
                             MarketId = m.MarketId,
                             MarketName = m.MarketName,
                             Commision = m.Commision,
                             UserId = m.UserId,
                             UserName = u.UserName
                         });

            return await  query.ToListAsync();
        }






    }
}
