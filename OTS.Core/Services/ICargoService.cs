using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface ICargoService
    {
        Task<IEnumerable<Cargo>> GetAllCargos();
        Task<Cargo> GetCargoById(int id);
        Task<Cargo> CreateCargo(Cargo newCargo);
        Task UpdateCargo(Cargo cargoToBeUpdated, Cargo cargo);
        Task DeleteCargo(Cargo cargo);
    }
}
