using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MyTest.ProxyClass;

using Newtonsoft.Json;


namespace MyTest.Controllers
{
    public class HomeController : Controller
    {
        IICUTechservice techservice = new IICUTechservice();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        { 

            string res = techservice.Login(email, password, null);
            Dictionary<string, string> loginResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);
            if (loginResult.ContainsKey("ResultCode") && loginResult.ContainsValue("-1"))
            {
                return PartialView("Error", loginResult);
            }
            else
            {
                return PartialView("Response", loginResult);
            }
        }



    }
}