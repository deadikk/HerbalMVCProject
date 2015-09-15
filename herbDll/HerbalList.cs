using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herbDllProj
{
    public class HerbalList
    {

        private static List<herbals> herbs;
        public static List<herbals> herbals { get { return herbs; } }

        private static readonly herbalDBEntities context;

        static HerbalList()
        {
            Console.WriteLine("HerbalList static constructor");
            if (context == null)
            {
                context = new herbalDBEntities();
            }
            if (herbs == null)
            {
                herbs = context.herbals.ToList();
            }

        }

        public static List<string> getLatinListByFirstSymbols(string symbols)
        {
            List<string> temp = new List<string>();
            foreach (var item in HerbalList.herbals.Where(h => h.name_latin.StartsWith(symbols, StringComparison.CurrentCultureIgnoreCase)).ToList())
            {
                temp.Add(item.name_latin);
            }
            return temp;
        }

        public static List<herbals> getLatinListByAnySymbols(string symbols)
        {
            return HerbalList.herbals.Where(h => h.name_latin.ToLower().Contains(symbols.ToLower())).ToList();
        }


        public static List<herbals> getListByAnyRussianSymbols(string symbols)
        {
            List<herbals> result = new List<herbals>();

            foreach (var item in HerbalList.herbals)
            {

                if (item.russianNames.Find(x => x.ToLower().Contains(symbols.ToLower())) != null)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static List<HerbalList.RusLatinDictionary> getDictionaryByRussianSymbols(string symbols)
        {
            List<HerbalList.RusLatinDictionary> result = new List<HerbalList.RusLatinDictionary>();
            foreach (var item in herbals)
            {
                foreach (var name in item.russianNames)
                {
                    if (name.StartsWith(symbols, StringComparison.CurrentCultureIgnoreCase))
                    {
                        result.Add(new HerbalList.RusLatinDictionary(name, item.name_latin));
                    }
                }
            }
            return result;
        }

        public class RusLatinDictionary
        {
            public string key;
            public string value;
            public RusLatinDictionary(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public static List<herbals> getListByReceip(string symbols)
        {
            List<herbals> result = new List<herbals>();
            foreach (var item in HerbalList.herbals)
            {
                List<string> receips = item.receipsTxt.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (receips == null) continue;

                /*foreach (string receip in receips)
                {
                    receip.Split(new string[] { ":\n", ": \n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    
                }*/

                if (receips.Exists(x => x.ToLower().Contains(symbols.ToLower().Substring(0,symbols.Length-2))))
                {
                    result.Add(item);
                }  

            }
            return result;
        }

        public static List<herbals> getRelatedHerbs(string mainLatinName)
        {
            return HerbalList.herbals.Where(h => h.name_latin.ToLower().Contains(mainLatinName.Split(' ')[0].ToLower()) && h.name_latin != mainLatinName).ToList();
        }

    }


}
