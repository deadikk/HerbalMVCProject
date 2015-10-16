using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herbDllProj
{
    public partial class herbals
    {
        public String selectedName { get; set; }
        private List<string> _russianNames;
        public List<string> russianNames
        {
            get
            {
                if (_russianNames == null)
                {
                    _russianNames = name_russian.Split(',').OrderBy(x=>x).ToList();
                }
                return _russianNames;
            }
        }
        
        public List<string> russianNamesWithoutSelected
        {
            get
            {
                if (_russianNames != null)
                {
                    List<string> temp = _russianNames;
                    temp.Remove(selectedName);
                    return temp;
                }
                return null;
            }
        }       

        
    }

    
}
