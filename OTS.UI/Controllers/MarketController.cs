using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OTS.Core.Services;
using OTS.Model;
using OTS.UI.Attribute;
using OTS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Controllers
{
    [Auth]
    public class MarketController : Controller
    {
        private readonly IMarketService _marketService;
        public MarketController(IMarketService marketService)
        {
            this._marketService = marketService;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _marketService.GetAllMarketWithUser();
            return View(list);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(MarketVM marketVM)
        {
            var value = HttpContext.Session.GetString("SessionContext");
            SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);

            Market market = new Market()
            {
                MarketName = marketVM.MarketName,
                Commision = marketVM.Commision,
                UserId = scon.UserId,
            };
            await _marketService.CreateMarket(market);
            return Redirect("/Market/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Market/Index");
            }

            Market market = await _marketService.GetMarketById(Id.Value);
            if (market == null)
            {
                return Redirect("/Market/Index");
            }

            return View(market);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MarketVM marketVM)
        {
            if (ModelState.IsValid)
            {
                var value = HttpContext.Session.GetString("SessionContext");
                SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);

                Market market = new Market()
                {
                    MarketName = marketVM.MarketName,
                    Commision = marketVM.Commision,
                    UserId = scon.UserId
                };
                await _marketService.UpdateMarketWithId(market, marketVM.MarketId);
                return Redirect("/Market/Index");
            }
            else
            {
                return Redirect("/Market/Index");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Market/Index");
            }
            await _marketService.DeleteMarketWithId(Id.Value);
            return Redirect("/Market/Index");
        }

    }
}
