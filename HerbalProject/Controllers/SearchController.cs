using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HerbalProject.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /SearchResult/

        public ActionResult Index()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult latinLetters()
        {

            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (char x = 'A'; x <= 'Z'; x++, i++)
            {
                sb.Append(x);
            }

            return PartialView("_Letters", sb.ToString());
        }
        [ChildActionOnly]
        public ActionResult rusLetters()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (char x = 'А'; x <= 'Щ'; x++, i++)
            {
                sb.Append(x);
            }
            for (char x = 'Э'; x <= 'Я'; x++, i++)
            {
                sb.Append(x);
            }

            return PartialView("_Letters", sb.ToString());
        }

        
        public ActionResult textList(string letter)
        {
            if (letter == null || letter.Length > 1)
            {

                return View("_nothingToShow");
            }

            char symbol = letter.ToUpper()[0];

            if (symbol >= 65 && symbol <= 90)
            {
                return View("_TextListLatin",herbDllProj.HerbalList.getLatinListByFirstSymbols(letter));

            }

            if ((symbol >= 1040 && symbol <= 1065) || (symbol > 1068 && symbol <= 1071))
            {
                return View("_TextListRus", herbDllProj.HerbalList.getDictionaryByRussianSymbols(letter));
            }

            return View("_nothingToShow");
        }

        
       

        public ActionResult searchAll(string s)
        {
            if (s.Length < 3)
            {
                ViewBag.message = "Введите более 3-х символов для корректного поиска.";
                return View("_nothingToShow");
            }
            List<herbDllProj.herbals> temp = new List<herbDllProj.herbals>();
            temp = herbDllProj.HerbalList.getLatinListByAnySymbols(s);
            if (temp == null || temp.Count < 1)
            {
                temp = herbDllProj.HerbalList.getListByAnyRussianSymbols(s);
            }
            if (temp == null || temp.Count < 1)
            {
                return View("_nothingToShow");
            }
            temp.ForEach(h => h.russianNames.Sort());
            return View("_CoolList", temp);

        }

        public ActionResult searchReseips(string sr)
        {
            if (sr.Length < 3)
            {
                ViewBag.message = "Введите более 3-х символов для корректного поиска.";
                return View("_nothingToShow");
            }

            List<herbDllProj.herbals> temp = new List<herbDllProj.herbals>();

            temp = herbDllProj.HerbalList.getListByReceip(sr);
            if (temp == null || temp.Count < 1)
            {
                return View("_nothingToShow");
            }
            return View("_CoolList", temp);
        }
    }
}
