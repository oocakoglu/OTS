using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Attribute
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var myContext = filterContext.HttpContext;
            //if (myContext.Session.GetString("SessionContext") != null)
            //{
            //    base.OnActionExecuting(filterContext);
            //}
            //else
            //{
            //    filterContext.Result = new RedirectToRouteResult(new { action = "Index", controller = "Login" });
            //}

            var myContext = filterContext.HttpContext;
            if (myContext.Session.GetString("SessionContext") == null)
            {                
                SessionContext _sessionContext = new SessionContext()
                {
                    UserId = 2,
                    UserName = "Sample User",
                    ImageUrl = ""
                };
                string _session = _sessionContext.ToJson();
                myContext.Session.SetString("SessionContext", _session);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
