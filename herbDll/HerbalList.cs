using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herbDllProj
{
    public class HerbalList
    {

        private  List<herbals> herbs;
        public  List<herbals> herbals { get { return herbs; } }

        private readonly herbalDBEntities context;

        public HerbalList()
        {
            
            if (context == null)
            {
                context = new herbalDBEntities();
            }
            if (herbs == null)
            {
                herbs = context.herbals.ToList();
            }

        }

        public  List<string> getLatinListByFirstSymbols(string symbols)
        {
            List<string> temp = herbals.Where(h => h.name_latin.StartsWith(symbols, StringComparison.CurrentCultureIgnoreCase)).ToList().Select(item => item.name_latin).ToList();
            temp.Sort();
            return temp;
        }

        public  List<herbals> getLatinListByAnySymbols(string symbols)
        {
            List<herbals> result = new List<herbals>();
            result = herbals.Where(h => h.name_latin.ToLower().Contains(symbols.ToLower())).ToList();

            return result.OrderBy(n => n.name_latin).ToList();
        }


        public  List<herbals> getListByAnyRussianSymbols(string symbols)
        {
            List<herbals> result = herbals.Where(item => item.russianNames.Find(x => x.ToLower().Contains(symbols.ToLower())) != null).ToList();

            return result.OrderBy(n => n.name_latin).ToList();
        }

        public  List<HerbalList.RusLatinDictionary> getDictionaryByRussianSymbols(string symbols)
        {
            List<HerbalList.RusLatinDictionary> result = (from item in herbals from name in item.russianNames where name.StartsWith(symbols, StringComparison.CurrentCultureIgnoreCase) select new HerbalList.RusLatinDictionary(name, item.name_latin)).ToList();

            return result.OrderBy(n=>n.key).ToList();
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

        public  List<herbals> getListByReceip(string symbols)
        {
            if (symbols == "givemeallherbalsplease")
            {
                return herbals;
            }

            List<herbals> result = (from item in herbals let receips = item.receipsTxt.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() where receips.Exists(x => x.ToLower().Contains(symbols.ToLower().Substring(0, symbols.Length - 1))) select item).ToList();

            /*if (result.Count < 10)
            {
                result.AddRange(from item in herbals let receips = item.receipsTxt.Split(new string[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries).ToList() where receips.Exists(x => x.ToLower().Contains(symbols.ToLower().Substring(0, symbols.Length - 1))) select item);
            }
             * */
            return result;
        }

        public  List<herbals> getRelatedHerbs(string mainLatinName)
        {
            List<herbals> result = new List<herbals>();
            result.AddRange(herbals.Where(h => h.name_latin.ToLower().Contains(mainLatinName.Split(' ')[0].ToLower()) && h.name_latin != mainLatinName).ToList());

            //закоментил, потому что слова вроде "официальный" не связаны
            /*if (result.Count < 5 && mainLatinName.Split(' ').Length > 1)
            {
                result.AddRange(HerbalList.herbals.Where(h => h.name_latin.ToLower().Contains(mainLatinName.Split(' ')[1].ToLower()) && h.name_latin != mainLatinName).ToList());
            }
            if (result.Count < 10 && mainLatinName.Split(' ').Length > 2)
            {
                result.AddRange(HerbalList.herbals.Where(h => h.name_latin.ToLower().Contains(mainLatinName.Split(' ')[2].ToLower()) && h.name_latin != mainLatinName).ToList());
            }*/

            //return result;
            return result.Take(10).ToList();

        }

    }


}
