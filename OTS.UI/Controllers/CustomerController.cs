using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OTS.Core.Services;
using OTS.Model;
using OTS.UI.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Controllers
{
    [Auth]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMarketService _marketService;
        public CustomerController(ICustomerService customerService, IMarketService marketService)
        {
            this._customerService = customerService;
            this._marketService = marketService;
        }

        public async Task<IActionResult> Index()
        {
             var list = await _customerService.GetCustomerList();
             return View(list);
        }


        [HttpPost]
        public async Task<IActionResult> CustomerSearch(string sPhone)
        {
            Customer customer = await _customerService.GetCustomerfromPhone(sPhone);
            if (customer != null)
            {
                return Json(customer);

            }
            else
            {
                return Json(false);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var list = await _marketService.GetAllMarket();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer)
        {
            var value = HttpContext.Session.GetString("SessionContext");
            SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);
            customer.UserId = scon.UserId;
            await _customerService.CreateCustomer(customer);
            return Redirect("/Customer/Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Customer/Index");
            }

            Customer customer = await _customerService.GetCustomerById(Id.Value);
            if (customer == null)
            {
                return Redirect("/Customer/Index");
            }

            ViewBag.market = await _marketService.GetAllMarket();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var value = HttpContext.Session.GetString("SessionContext");
                SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);
                customer.UserId = scon.UserId;
                await _customerService.UpdateCustomerById(customer, customer.CustomerId);         
                return Redirect("/Customer/Index");
            }
            else
            {
                return Redirect("/Customer/Index");
            }
        }

    
        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Customer/Index");
            }
            await _customerService.DeleteCustomerById(Id.Value);
            return Redirect("/Customer/Index");
        }

    }
}
