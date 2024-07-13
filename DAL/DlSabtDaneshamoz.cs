using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlSabtDaneshamoz
    {
        public List<MemberRegistration> Read()
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.UserType == "دانش آموز" select i).ToList();
        }
        public List<MemberRegistration> Read(string Text)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.UserType == "دانش آموز" && (i.Name.Contains(Text) || i.NationalCode.Contains(Text)) select i).ToList();
        }
        public List<MemberRegistration> ReadbyClassName(string Text)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.ClassName == Text select i).ToList();
        }
        public string Update(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration mr = new MemberRegistration();
                mr = q.Single();
                mr.ClassName = m.ClassName;
                mr.Classroom_id = m.Classroom_id;
                db.SaveChanges();
                return "دانش آموز بروزرسانی شد";
            }
            return "";
        }
        public List<Classroom> ReadClass()
        {
            return ((new LibraryEntities()).Classroom).ToList();
        }
        public MemberRegistration Read(int id)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.id == id select i).Single();
        }
        public string Reset()
        {
            List<int> id = (from i in (new LibraryEntities()).MemberRegistration where i.Classroom_id != null select i.id).ToList();
            MemberRegistration m = new MemberRegistration();
            foreach (var item in id)
            {
                m.ClassName = "";
                m.Classroom_id = null;
                Update(item, m);
            }
            return "بازنشانی کلاس ها با موفقیت انجام شد";
        }
    }
}
