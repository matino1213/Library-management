using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class DlTamdidOzviat
    {
        public List<MemberRegistration> Read()
        {
            return (from i in (new LibraryEntities()).MemberRegistration orderby i.id descending select i).ToList();
        }
        public MemberRegistration Read(int id)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.id == id select i).Single();
        }
        public string Update(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration mr = new MemberRegistration();
                mr = q.Single();
                mr.Status = m.Status;
                mr.Credit = m.Credit;
                mr.Date = m.Date;
                mr.CompletionDate = m.CompletionDate;
                db.SaveChanges();
                return "تمدید با موفقیت انجام شد";
            }
            return "";
        }
        public List<MemberRegistration> Read(string Text)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.Name.Contains(Text) || i.PhoneNumber.Contains(Text) || i.NationalCode.Contains(Text) orderby i.id descending select i).ToList();
        }
    }
}
