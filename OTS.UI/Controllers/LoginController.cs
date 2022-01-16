using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OTS.Model;
using OTS.Core.Services;
using OTS.UI.Attribute;
using OTS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginControl(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUserLogin(loginVM.UserName, loginVM.Password);
                if (user != null)
                {
                    SessionContext _sessionContext = new SessionContext()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        ImageUrl = user.ImageUrl
                    };
                   string _session = _sessionContext.ToJson();
                   HttpContext.Session.SetString("SessionContext", _session);
                   return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Redirect("~/Login/Index");
            }            
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }

    }
}
