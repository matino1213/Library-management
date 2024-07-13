using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
  public class DlVirayeshKetabdar
    {
        public bool Exist(Librarians l, int id)
        {
            LibraryEntities db = new LibraryEntities();
            foreach (var item in db.Librarians)
            {
                if (item.Log_id == id)
                {
                    continue;
                }
                else if (l.NationalCode == item.NationalCode)
                {
                    return true;
                }
            }
            return false;
        }
        public string UpdatePas(string Pas, string NewPas)
        {
            string UserName = (from i in (new LibraryEntities().log) where i.id == 1 select i.username).Single();
            int id = (from i in (new LibraryEntities().Librarians) where i.Log_UserName == UserName select i.Log_id).Single();
            LibraryEntities db = new LibraryEntities();
            var q = db.Librarians.Where(i => i.Log_id == id);
            if (q.Count() == 1)
            {
                Librarians l = new Librarians();
                l = q.Single();
                if (l.Log_Password == Pas)
                {
                    l.Log_Password = NewPas;
                    db.SaveChanges();
                    return "رمز عبور با موفقیت بروزرسانی شد";
                }
                return "رمز عبور قبلی اشتباه است";
            }
            return "";
        }
        public string UpdateNCode(string NCode)
        {
            string UserName = (from i in (new LibraryEntities().log) where i.id == 1 select i.username).Single();
            int id = (from i in (new LibraryEntities().Librarians) where i.Log_UserName == UserName select i.Log_id).Single();
            LibraryEntities db = new LibraryEntities();
            var q = db.Librarians.Where(i => i.Log_id == id);
            if (q.Count() == 1)
            {
                Librarians l = new Librarians();
                l = q.Single();
                l.NationalCode = NCode;
                if (!Exist(l, id))
                {
                    db.SaveChanges();
                    return "کد ملی با موفقیت بروزرسانی شد";
                }
                else
                {
                    return "کد ملی تکراری است";
                }
            }
            return "";
        }
    }
}
