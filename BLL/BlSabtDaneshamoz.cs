using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BlSabtDaneshamoz
    {
        DlSabtDaneshamoz dls = new DlSabtDaneshamoz();
        public List<MemberRegistration> Read()
        {
            return dls.Read();
        }
        public List<MemberRegistration> Read(string Text)
        {
            return dls.Read(Text);
        }
        public List<MemberRegistration> ReadbyClassName(string Text)
        {
            return dls.ReadbyClassName(Text);
        }
        public string Update(int id, MemberRegistration m)
        {
            return dls.Update(id, m);
        }
        public List<Classroom> ReadClass()
        {
            return dls.ReadClass();
        }
        public MemberRegistration Read(int id)
        {
            return dls.Read(id);
        }
        public string Reset()
        {
            return dls.Reset();
        }
    }
}
