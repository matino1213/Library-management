using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class BlSabtKetabdar
    {
        DlSabtKetabdar dls = new DlSabtKetabdar();
        public string Create(Librarians l)
        {
            return dls.Create(l);
        }
    }
}
