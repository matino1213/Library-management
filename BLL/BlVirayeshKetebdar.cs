using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BlVirayeshKetebdar
    {
        DlVirayeshKetabdar dlv = new DlVirayeshKetabdar();
        public string UpdatePas(string Pas, string NewPas, string NewPasAgain)
        {
            if (NewPas == NewPasAgain)
            {
                return dlv.UpdatePas(Pas, NewPas);
            }
            return "رمز عبور و تکرار آن یکی نمی باشد";
        }
        public string UpdateNCode(string NCode)
        {
            return dlv.UpdateNCode(NCode);
        }
    }
}
