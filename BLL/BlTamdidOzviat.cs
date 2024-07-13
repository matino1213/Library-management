using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class BlTamdidOzviat
    {
        DlTamdidOzviat dlt = new DlTamdidOzviat();
        DlAzaKetabkhane dla = new DlAzaKetabkhane();
        public List<MemberRegistration> Read()
        {
            dla.Check();
            return dlt.Read();
        }
        public MemberRegistration Read(int id)
        {
            return dlt.Read(id);
        }
        public List<MemberRegistration> Read(string Text)
        {
            return dlt.Read(Text);
        }
        public string Update(int id ,MemberRegistration m)
        {
            return dlt.Update(id, m);
        }
    }
}
