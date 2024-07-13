using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class DlSabtKetabdar
    {
        public bool Exist(Librarians l)
        {
            LibraryEntities db = new LibraryEntities();
            foreach (var item in db.Librarians)
            {
                if (l.Log_UserName == item.Log_UserName || l.NationalCode == item.NationalCode)
                {
                    return true;
                }
            }
            return false;
        }
        public string Create(Librarians l)
        {
            LibraryEntities db = new LibraryEntities();
            if (!Exist(l))
            {
                db.Librarians.Add(l);
                db.SaveChanges();
                return "کتابدار جدید ثبت شد";
            }
            return "نام کاربری تکراری است";
        }
    }
}
