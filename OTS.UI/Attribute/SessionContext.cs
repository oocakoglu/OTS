using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Attribute
{
    public class SessionContext
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    //public static class Utilities
    //{
    //    public static int getUserId()
    //    {
    //        var value = HttpContext.Session.GetString("SessionContext");
    //        SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);
    //        return scon.UserId;
    //    }
    //}
     
}
