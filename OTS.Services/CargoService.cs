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
    public class CargoService : ICargoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CargoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cargo> GetCargoById(int cargoId)
        {
            return await _unitOfWork.Cargos.GetByIdAsync(cargoId);
        }

        public async Task<Cargo> CreateCargo(Cargo newCargo)
        {
            await _unitOfWork.Cargos.AddAsync(newCargo);
            await _unitOfWork.CommitAsync();
            return newCargo;
        }

        public async Task UpdateCargoById(Cargo upCargo, int cargoId)
        {
            Cargo cargo = await GetCargoById(cargoId);
            cargo.CargoName = upCargo.CargoName;
            cargo.UserId = upCargo.UserId;

            if (upCargo.CargoImageUrl != null)
            {
                cargo.CargoImageUrl = upCargo.CargoImageUrl;
            }           
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCargoById(int cargoId)
        {
            Cargo cargo = await GetCargoById(cargoId);
            _unitOfWork.Cargos.Remove(cargo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CargoList>> GetCargoList()
        {
            var query = (from c in _unitOfWork.Cargos.GetAllQuery()
                         join u in _unitOfWork.Users.GetAllQuery() on c.UserId equals u.UserId
                         select new CargoList
                         {
                             CargoId = c.CargoId,
                             CargoName = c.CargoName,
                             CargoImageUrl = c.CargoImageUrl,
                             UserId = c.UserId,
                             UserName = u.UserName
                         });

            return await query.ToListAsync();
        }




    }
}
