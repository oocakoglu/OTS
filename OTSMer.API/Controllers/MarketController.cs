using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OTS.Core.Services;
using OTS.Model;
using OTSMer.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.Controllers
{

    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;
        private readonly IMapper _mapper;

        public MarketController(IMarketService marketService, IMapper mapper)
        {
            this._mapper = mapper;
            this._marketService = marketService;
        }

        [HttpPost("")]
        public async Task<ActionResult<MarketDTO>> CreateMarket([FromBody] SaveMarketDTO saveMarketResource)
        {
            //var validator = new SaveUserResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveUserResource);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var marketToCreate = _mapper.Map<SaveMarketDTO, Market>(saveMarketResource);

            var newMarket = await _marketService.CreateMarket(marketToCreate);

            //var user = await _userService.GetUserById(newUser.UserId);

            var marketResource = _mapper.Map<Market, MarketDTO>(newMarket);

            return Ok(marketResource);
        }

    }
}
