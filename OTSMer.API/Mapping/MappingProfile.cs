using AutoMapper;
using OTS.Model;
using OTSMer.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Cargo, CargoDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Market, MarketDTO>();



            // Resource to Domain
            CreateMap<UserDTO, User>();
            CreateMap<SaveUserDTO, User>();
            CreateMap<MarketDTO, Market>();
            CreateMap<SaveMarketDTO, Market>();

            CreateMap<CargoDTO, Cargo>();
            CreateMap<CustomerDTO, Customer>();


            
            
        }

    }
}
