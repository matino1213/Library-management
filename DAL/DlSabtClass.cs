using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlSabtClass
    {
        public bool Exist(Classroom c,int id)
        {
            LibraryEntities db = new LibraryEntities();
            foreach (var item in db.Classroom)
            {
                if (Read(id).id == item.id)
                {
                    continue;
                }
                else if (c.ClassName == item.ClassName)
                {
                    return true;
                }
            }
            return false;
        }
        public string Create(Classroom c)
        {
            if (!Exist(c, 0))
            {
                LibraryEntities db = new LibraryEntities();
                db.Classroom.Add(c);
                db.SaveChanges();
                return "کلاس جدید ثبت شد";
            }
            return "کلاس موجود است";
        }
        public List<Classroom> Read()
        {
            return (from i in (new LibraryEntities()).Classroom orderby i.id descending select i).ToList();
        }
        public Classroom Read(int id)
        {
            return (from i in (new LibraryEntities()).Classroom where i.id == id select i).Single();
        }
        public void Delete(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.Classroom.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.Classroom.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public string Update(int id, Classroom c)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.Classroom.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                Classroom cl = new Classroom();
                cl = q.Single();
                cl.ClassName = c.ClassName;
                cl.ClassGrade = c.ClassGrade;
                if (!Exist(cl, id))
                {
                    db.SaveChanges();
                    return "کلاس بروزرسانی شد";
                }
                else
                {
                    return "کلاس موجود است";
                }
            }
            return "";
        }
        public void Check()
        {
            List<int> ClassName = (from i in (new LibraryEntities()).Classroom select i.id).ToList();
            foreach (var item in ClassName)
            {
                Classroom cl = new Classroom();
                cl.BookLoan = 0;
                updateCheck(item, cl);
                string a = Read(item).ClassName;
                List<int> Student = (from i in (new LibraryEntities()).MemberRegistration where i.ClassName == a select i.id).ToList();
                foreach (var item1 in Student)
                {
                    DlAzaKetabkhane dla = new DlAzaKetabkhane();
                    Classroom c = new Classroom();
                    int x = Read(item).BookLoan;
                    c.BookLoan = x + dla.Read(item1).BookLoan.Value;
                    updateCheck(item, c);
                }
            }
        }
        public void updateCheck(int id, Classroom c)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.Classroom.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                Classroom cl = new Classroom();
                cl = q.Single();
                cl.BookLoan = c.BookLoan;
                db.SaveChanges();
            }
        }
    }
}
