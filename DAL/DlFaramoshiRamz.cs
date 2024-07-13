using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlFaramoshiRamz
    {
        LibraryEntities db = new LibraryEntities();
        public byte Check(string username, string NationalCode)
        {
            List<Librarians> l = (from i in (new LibraryEntities().Librarians) select i).ToList();
            foreach (var item in l)
            {
                if (item.Log_UserName == username && item.NationalCode == NationalCode)
                {
                    return 1;
                }
            }
            return 0;
        }
        public string Password(string username)
        {
            string s = (from i in (new LibraryEntities().Librarians) where i.Log_UserName == username select i.Log_Password).Single();
            return s;
        }
    }
}
