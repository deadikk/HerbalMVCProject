using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using herbDllProj;

namespace HerbalProject.Controllers
{
    public class SearchController : Controller
    {
       
        private static HerbalList _herbalList;

        public SearchController()
        {
            if (_herbalList == null)
            {
                _herbalList = new HerbalList();
            }
            
        }
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

            for (char x = 'А'; x <= 'Я'; x++, i++)
            {
                if (x != 'Й' && x != 'Ь' && x != 'Ъ' && x != 'Ё' && x != 'Ы')
                {
                    sb.Append(x);
                }

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
                return View("_TextListLatin", _herbalList.getLatinListByFirstSymbols(letter));

            }

            if ((symbol >= 1040 && symbol <= 1065) || (symbol > 1068 && symbol <= 1071))
            {
                return View("_TextListRus", _herbalList.getDictionaryByRussianSymbols(letter));
            }

            

            return View("_nothingToShow");
        }




        public ActionResult searchAll(string s)
        {
            try
            {
                if (s.Length < 3)
                {
                    ViewBag.message = "Введите более 3-х символов для корректного поиска.";
                    return View("_nothingToShow");
                }
                List<herbDllProj.herbals> temp = new List<herbDllProj.herbals>();
                temp = _herbalList.getLatinListByAnySymbols(s);
                if (temp == null || temp.Count < 1)
                {
                    temp = _herbalList.getListByAnyRussianSymbols(s);
                }
                if (temp == null || temp.Count < 1)
                {
                    return View("_nothingToShow");
                }
                temp.ForEach(h => h.russianNames.Sort());
                ViewBag.searchedText = s;
                ViewBag.Title = "Поиск: " + s;

                return View("_CoolList", temp);
            }
            catch
            {
                return View("_nothingToShow");
            }
        }

        public ActionResult searchReseips(string r)
        {
            try
            {
                if (r.Length < 4)
                {
                    ViewBag.message = "Введите более 3-х символов для корректного поиска.";
                    return View("_nothingToShow");
                }

                List<herbDllProj.herbals> temp = new List<herbDllProj.herbals>();

                temp = _herbalList.getListByReceip(r);
                if (temp == null || temp.Count < 1)
                {
                    return View("_nothingToShow");
                }
                ViewBag.searchedText = r;
                ViewBag.Title = "Поиск: " + r;
                return View("_CoolList", temp);
            }
            catch
            {
                return View("_nothingToShow");
            }
        }
    }
}
