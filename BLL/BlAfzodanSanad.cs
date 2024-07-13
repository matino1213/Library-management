using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class BlAfzodanSanad
    {
        DlAfzodanSanad dls = new DlAfzodanSanad();
        public string Create(DocumentRegistration d)
        {
            return dls.Create(d);
        }
        public List<DocumentRegistration> Read()
        {
            return dls.Read();
        }
        public DocumentRegistration Read(int id)
        {
            return dls.Read(id);
        }
        public List<DocumentRegistration> Read(string Text)
        {
            return dls.Read(Text);
        }
        public void Delete(int id)
        {
            dls.Delete(id);
        }
        public string Update(int id,DocumentRegistration d)
        {
            return dls.Update(id, d);
        }
        public bool Check(int id)
        {
            return dls.Check(id);
        }
    }
}
