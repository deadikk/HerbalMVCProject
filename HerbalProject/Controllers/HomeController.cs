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
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            
            return View();
            
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchLatin(string searchText)
        {
            return View();
        }

        public ActionResult SearchRus(string searchText)
        {
            return View();
        }

    }
}
