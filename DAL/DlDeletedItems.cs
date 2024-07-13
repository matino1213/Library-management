using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlDeletedItems
    {
        public List<DeletedBookLoan> ReadBookLoan()
        {
            return (from i in (new LibraryEntities().DeletedBookLoan) select i).ToList();
        }
        public List<DeletedDocument> ReadDoc()
        {
            return (from i in (new LibraryEntities().DeletedDocument) select i).ToList();
        }
        public List<DeletedMembers> ReadMem()
        {
            return (from i in (new LibraryEntities().DeletedMembers) select i).ToList();
        }
        public DeletedBookLoan ReadBookLoan(int id)
        {
            return (from i in (new LibraryEntities().DeletedBookLoan)where i.id == id select i).Single();
        }
        public DeletedDocument ReadDoc(int id)
        {
            return (from i in (new LibraryEntities().DeletedDocument)where i.id == id select i).Single();
        }
        public DeletedMembers ReadMem(int id)
        {
            return (from i in (new LibraryEntities().DeletedMembers)where i.id == id select i).Single();
        }
        public string CreateDoc(DocumentRegistration d)
        {
            LibraryEntities db = new LibraryEntities();
            db.DocumentRegistration.Add(d);
            db.SaveChanges();
            return "کتاب با موفقیت بازگردانی شد";
        }
        public string CreateMem(MemberRegistration m)
        {
            if (!Exist(m))
            {
                LibraryEntities db = new LibraryEntities();
                db.MemberRegistration.Add(m);
                db.SaveChanges();
                return "عضو با موفقیت بازگردانی شد";
            }
            else
            {
                return "کابر موجود است";
            }
        }
        public void DeleteBookLoan(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DeletedBookLoan.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.DeletedBookLoan.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public void DeleteDoc(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DeletedDocument.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.DeletedDocument.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public void DeleteMem(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DeletedMembers.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.DeletedMembers.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public bool Exist(MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            foreach (var item in db.MemberRegistration)
            {if (m.NationalCode == item.NationalCode)
                {
                    return true;
                }
            }
            return false;
        }
        public List<DeletedDocument> ReadDoc(string Text)
        {
            return (from i in (new LibraryEntities()).DeletedDocument where i.BookName.Contains(Text) || i.Writer.Contains(Text) || i.Publisher.Contains(Text) || i.Topic.Contains(Text) select i).ToList();
        }
        public List<DeletedMembers> ReadMem(string Text)
        {
            return (from i in (new LibraryEntities()).DeletedMembers where i.Name.Contains(Text) || i.PhoneNumber.Contains(Text) || i.NationalCode.Contains(Text) select i).ToList();
        }
        public List<DeletedBookLoan> ReadBookLoan(string Text)
        {
            return (from i in (new LibraryEntities()).DeletedBookLoan where i.Name.Contains(Text) || i.BookName.Contains(Text) select i).ToList();
        }
    }
}
