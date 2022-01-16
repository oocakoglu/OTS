using OTS.Core;
using OTS.Model;
using OTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Services
{
    public class CargoService : ICargoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CargoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cargo> CreateCargo(Cargo newCargo)
        {
            await _unitOfWork.Cargos.AddAsync(newCargo);
            await _unitOfWork.CommitAsync();
            return newCargo;
        }

        public async Task DeleteCargo(Cargo cargo)
        {
            _unitOfWork.Cargos.Remove(cargo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            return await _unitOfWork.Cargos.GetAllAsync();
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            return await _unitOfWork.Cargos.GetByIdAsync(id);
        }

        public async Task UpdateCargo(Cargo cargoToBeUpdated, Cargo cargo)
        {
            cargoToBeUpdated.CargoName = cargo.CargoName;
            cargoToBeUpdated.CargoImageUrl = cargo.CargoImageUrl;

            await _unitOfWork.CommitAsync();
        }
    }
}
