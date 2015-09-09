using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerbalProject.Controllers
{
    public class HerbController : Controller
    {
        //
        // GET: /Herb/
        [HttpGet]
        public ActionResult Index(string name)
        {
            herbDllProj.herbals temp = herbDllProj.HerbalList.herbals.Find(n => n.name_latin == name.Replace('_', ' '));
            if (temp == null)
            {
                return View("_nothingToShow");
            } 
            return View(temp);
        }

    }
}
