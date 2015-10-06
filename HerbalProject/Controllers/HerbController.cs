using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using herbDllProj;

namespace HerbalProject.Controllers
{
    public class HerbController : Controller
    {
        private static HerbalList _herbalList;

        public HerbController()
        {
            if (_herbalList == null)
            {
                _herbalList = new HerbalList();
            }

        }

        [HttpGet]
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                return View("_nothingToShow");
            }
            herbDllProj.herbals temp = _herbalList.herbals.Find(n => n.name_latin == name.Replace('_', ' ').Replace('!', '.'));
            if (temp == null)
            {
                return View("_nothingToShow");
            }
            ViewBag.relatedHerbs = _herbalList.getRelatedHerbs(temp.name_latin);

            StringBuilder sb = new StringBuilder();

            foreach (string item in temp.russianNames)
            {
                sb.Append(item + ",");
            }
            ViewBag.Description = sb.ToString().TrimEnd(',');
            return View(temp);
        }

    }
}
