using OTS.Core.Repositories;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Data.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(OTSDbContext context) : base(context)
        {
        }

        



    }
}
