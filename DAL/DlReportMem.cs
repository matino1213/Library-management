using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlReportMem
    {
        public List<UserReport> Read()
        {
            return (from i in (new LibraryEntities()).UserReport orderby i.BookLoan descending select i).ToList();
        }
        private MemberRegistration ReadMem(int id)
        {
            return (from i in (new LibraryEntities().MemberRegistration) where i.id == id select i).Single();
        }
        public List<UserReport> Read(string text, string t)
        {
            return (from i in (new LibraryEntities().UserReport) where i.UserType.Contains(t) && (i.Name.Contains(text) || i.NationalCode.Contains(text)) orderby i.BookLoan descending select i).ToList();
        }
        public UserReport Read(int id)
        {
            return (from i in (new LibraryEntities().UserReport) where i.id == id select i).Single();
        }
        public int BookLoan()
        {
            List<int> id = (from i in (new LibraryEntities().UserReport) select i.id).ToList();
            int sum = 0;
            foreach (var item in id)
            {
                sum += Read(item).BookLoan;
            }
            return sum;
        }
        public List<UserReport> ReadFilter(string text)
        {
            return (from i in (new LibraryEntities().UserReport) where i.UserType == text orderby i.BookLoan descending select i).ToList();
        }
        public List<UserReport> ReadClass(string text)
        {
            return (from i in (new LibraryEntities().UserReport) where i.ClassName == text orderby i.BookLoan descending select i).ToList();
        }
        public List<Classroom> Class()
        {
            return (from i in (new LibraryEntities().Classroom) orderby i.BookLoan descending select i).ToList();
        }
        public void UpdateByDate(DateTime d1, DateTime d2)
        {
            List<int> x = (from i in (new LibraryEntities().MemberRegistration) select i.id).ToList();
            foreach (var item in x)
            {
                MemberRegistration m = new MemberRegistration();
                m.BookLoan = (from i in (new LibraryEntities().BookLoan) where (i.Date >= d1 && i.Date <= d2) && i.mem_id == item select i).Count();
                Update(item, m);
            }
        }
        private void Update(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration mm = new MemberRegistration();
                mm = q.Single();
                mm.BookLoan = m.BookLoan;
                db.SaveChanges();
            }
        }
        public void UpdateAll()
        {
            List<int> x = (from i in (new LibraryEntities().MemberRegistration) select i.id).ToList();
            foreach (var item in x)
            {
                MemberRegistration m = new MemberRegistration();
                m.BookLoan = (from i in (new LibraryEntities().BookLoan) where i.mem_id == item && i.Condition != "رزرو" select i).Count();
                Update(item, m);
            }
        }
    }
}
