using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BlFaramoshiRamz
    {
        DlFaramoshiRamz dlf = new DlFaramoshiRamz();
        public byte Check(string username, string NationalCode)
        {
            return dlf.Check(username, NationalCode);
        }
        public string Password(string username)
        {
            return dlf.Password(username);
        }
    }
}
