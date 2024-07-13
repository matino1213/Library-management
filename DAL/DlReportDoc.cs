using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlReportDoc
    {
        public List<BookReport> Read()
        {
            return (from i in (new LibraryEntities()).BookReport orderby i.BookLoan descending select i).ToList();
        }
        private DocumentRegistration ReadDoc(int id)
        {
            return (from i in (new LibraryEntities().DocumentRegistration) where i.id == id select i).Single();
        }
        public void UpdateByDate(DateTime d1, DateTime d2)
        {
            List<int> x = (from i in (new LibraryEntities().DocumentRegistration) select i.id).ToList();
            foreach (var item in x)
            {
                DocumentRegistration m = new DocumentRegistration();
                m.BookLoan = (from i in (new LibraryEntities().BookLoan) where (i.Date >= d1 && i.Date <= d2) && i.doc_id == item select i).Count();
                Update(item, m);
            }
        }
        private void Update(int id, DocumentRegistration d)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DocumentRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                DocumentRegistration dd = new DocumentRegistration();
                dd = q.Single();
                dd.BookLoan = d.BookLoan;
                db.SaveChanges();
            }
        }
        public void UpdateAll()
        {
            List<int> x = (from i in (new LibraryEntities().DocumentRegistration) select i.id).ToList();
            foreach (var item in x)
            {
                DocumentRegistration m = new DocumentRegistration();
                m.BookLoan = (from i in (new LibraryEntities().BookLoan) where i.doc_id == item && i.Condition != "رزرو" select i).Count();
                Update(item, m);
            }
        }
        public List<BookReport> Read(string text)
        {
            return (from i in (new LibraryEntities().BookReport) where i.BookName.Contains(text) || i.Writer.Contains(text) orderby i.BookLoan descending select i).ToList();
        }
        public BookReport Read(int id)
        {
            return (from i in (new LibraryEntities().BookReport) where i.id == id select i).Single();
        }
        public int BookLoan()
        {
            List<int> id = (from i in (new LibraryEntities().BookReport) select i.id).ToList();
            int sum = 0;
            foreach (var item in id)
            {
                sum += Read(item).BookLoan;
            }
            return sum;
        }
    }
}
