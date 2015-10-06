using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using herbDllProj;

namespace HerbalProject.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}
