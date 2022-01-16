using OTS.Core.DTOModels;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface ICargoService
    {
        
        Task<Cargo> GetCargoById(int cargoId);
        Task<Cargo> CreateCargo(Cargo newCargo);
        Task UpdateCargoById(Cargo upCargo, int cargoId);
        Task DeleteCargoById(int cargoId);
        Task<IEnumerable<CargoList>> GetCargoList();
        //Task<IEnumerable<Cargo>> GetAllCargos();
    }
}
