using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
   public class BlAzaKetabkhane
    {
        DlAzaKetabkhane dla = new DlAzaKetabkhane();
        public string Create(MemberRegistration m)
        {
            return dla.Create(m);
        }
        public List<MemberRegistration> Read()
        {
            dla.Check();
            return dla.Read();
        }
        public MemberRegistration Read(int id)
        {
            return dla.Read(id);
        }
        public List<MemberRegistration> Read(string Text)
        {
            return dla.Read(Text);
        }
        public void Delete(int id)
        {
            dla.Delete(id);
        }
        public string Update(int id, MemberRegistration m)
        {
            return dla.Update(id, m);
        }
        public bool CheckExist(int id)
        {
            return dla.CheckExist(id);
        }
        public List<Classroom> ReadClass()
        {
            return dla.ReadClass();
        }
    }
}
