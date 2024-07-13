using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BlSabtClass
    {
        DlSabtClass dls = new DlSabtClass();
        public string Create(Classroom c)
        {
            return dls.Create(c);
        }
        public List<Classroom> Read()
        {
            return dls.Read();
        }
        public void Delete(int id)
        {
            dls.Delete(id);
        }
        public Classroom Read(int id)
        {
            return dls.Read(id);
        }
        public string Update(int id, Classroom c)
        {
            return dls.Update(id, c);
        }
        public void Check()
        {
            dls.Check();
        }
    }
}
