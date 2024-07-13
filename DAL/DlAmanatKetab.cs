using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlAmanatKetab
    {
        public List<MemberRegistration> Read()
        {
            return (from i in (new LibraryEntities()).MemberRegistration orderby i.id descending select i).ToList();
        }
        public List<DocumentRegistration> Read1()
        {
            return (from i in (new LibraryEntities()).DocumentRegistration orderby i.id descending select i).ToList();
        }
        public MemberRegistration Read(int id)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.id == id select i).Single();
        }
        public List<MemberRegistration> Read(string Text)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.Name.Contains(Text) || i.PhoneNumber.Contains(Text) || i.NationalCode.Contains(Text) orderby i.id descending select i).ToList();
        }
        public DocumentRegistration Read1(int id)
        {
            return (from i in (new LibraryEntities()).DocumentRegistration where i.id == id select i).Single();
        }
        public List<DocumentRegistration> Read1(string Text)
        {
            return (from i in (new LibraryEntities()).DocumentRegistration where i.BookName.Contains(Text) || i.Writer.Contains(Text) orderby i.id descending select i).ToList();
        }
        public string Update(int id, DocumentRegistration d)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DocumentRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                DocumentRegistration dd = new DocumentRegistration();
                dd = q.Single();
                dd.Inventory = d.Inventory;
                db.SaveChanges();
                return "";
            }
            return "";
        }
        public string Create(BookLoan b)
        {
            LibraryEntities db = new LibraryEntities();
            db.BookLoan.Add(b);
            db.SaveChanges();
            return "امانت با موفقیت ثبت شد";

        }
        public List<BookLoan> Read2()
        {
            return (from i in (new LibraryEntities()).BookLoan orderby i.id descending select i).ToList();
        }
        public List<BookLoan> Read2(string Text)
        {
            return (from i in (new LibraryEntities()).BookLoan where i.Name.Contains(Text) || i.BookName.Contains(Text) orderby i.id descending select i).ToList();
        }
        public List<BookLoan> Read3(string Text)
        {
            return (from i in (new LibraryEntities()).BookLoan where i.Condition == Text orderby i.id descending select i).ToList();
        }
        public List<BookLoan> Read3(string Text, string text)
        {
            return (from i in (new LibraryEntities()).BookLoan where i.Condition == Text || i.Condition == text orderby i.id descending select i).ToList();
        }
        public string Update1(int id, BookLoan b)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.BookLoan.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                BookLoan bo = new BookLoan();
                bo = q.Single();
                bo.Condition = b.Condition;
                bo.DateReceived = b.DateReceived;
                db.SaveChanges();
                return "امانت با موفقیت دریافت شد";
            }
            return "ERROR";
        }
        public BookLoan Read2(int id)
        {
            return (from i in (new LibraryEntities()).BookLoan where i.id == id select i).Single();
        }
        public List<BookLoan> Read2(string Text, string t)
        {
            return (from i in (new LibraryEntities()).BookLoan where (i.Name.Contains(Text) || i.BookName.Contains(Text)) && i.Condition == t orderby i.id descending select i).ToList();
        }
        public string Update2(int id, BookLoan b)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.BookLoan.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                BookLoan bo = new BookLoan();
                bo = q.Single();
                bo.Condition = b.Condition;
                bo.Date = b.Date;
                bo.ReturnDate = b.ReturnDate;
                bo.Description = b.Description;
                db.SaveChanges();
                return "امانت با موفقیت ثبت شد";
            }
            return "ERROR";
        }
        public void Delete(int id)
        {
            LibraryEntities db = new LibraryEntities();
            DeletedBookLoan d = new DeletedBookLoan();
            d.mem_id = Read2(id).mem_id;
            d.doc_id = Read2(id).doc_id;
            d.Name = Read2(id).Name;
            d.BookName = Read2(id).BookName;
            d.Description = Read2(id).Description;
            d.Condition = Read2(id).Condition;
            d.Date = Read2(id).Date;
            d.ReturnDate = Read2(id).ReturnDate;
            d.DateReceived = Read2(id).DateReceived;
            db.DeletedBookLoan.Add(d);
            db.SaveChanges();
            var q = db.BookLoan.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.BookLoan.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public string Update2(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration me = new MemberRegistration();
                me = q.Single();
                me.Status = m.Status;
                me.Credit = m.Credit;
                db.SaveChanges();
                return "تمدید با موفقیت انجام شد";
            }
            return "ERROR";
        }
        public string UpdateChech(int id, BookLoan b)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.BookLoan.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                BookLoan bo = new BookLoan();
                bo = q.Single();
                bo.Condition = b.Condition;
                db.SaveChanges();
                return "";
            }
            return "ERROR";
        }
        public void Check()
        {
            List<int> id = (from i in (new LibraryEntities()).BookLoan where i.Condition == "فعال" && i.ReturnDate < DateTime.Now select i.id).ToList();
            foreach (var item in id)
            {
                BookLoan b = new BookLoan();
                b.Condition = "جریمه";
                UpdateChech(item, b);
            }
        }
        public void UpdateBookLoanMem(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration m= new MemberRegistration();
                m = q.Single();
                m.BookLoan = Read(id).BookLoan + 1;
                db.SaveChanges();
            }
        }
        public void UpdateBookLoanDoc(int id)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DocumentRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                DocumentRegistration d = new DocumentRegistration();
                d = q.Single();
                d.BookLoan = Read1(id).BookLoan + 1;
                db.SaveChanges();
            }
        }
        public bool ChechDelete()
        {
            List<BookLoan> b = (from i in (new LibraryEntities().BookLoan) where i.Condition == "فعال" || i.Condition == "جریمه" select i).ToList();
            if (b.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteAll()
        {
            LibraryEntities db = new LibraryEntities();
            List<int> id = (from i in (new LibraryEntities().BookLoan) select i.id).ToList();
            foreach (var item in id)
            {
                var q = db.BookLoan.Where(i => i.id == item);
                if (q.Count() == 1)
                {
                    db.BookLoan.Remove(q.Single());
                    db.SaveChanges();
                }
            }
        }
    }
}
