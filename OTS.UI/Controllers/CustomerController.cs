using Microsoft.AspNetCore.Mvc;
using OTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
             var list = await _customerService.GetCustomerList();
             return View(list);
        }


    }
}
