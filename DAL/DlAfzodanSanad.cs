using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class DlAfzodanSanad
    {
        public string Create(DocumentRegistration d)
        {
            LibraryEntities db = new LibraryEntities();
            db.DocumentRegistration.Add(d);
            db.SaveChanges();
            return "سند جدید ثبت شد";
        }
        public List<DocumentRegistration> Read()
        {
            return (from i in (new LibraryEntities()).DocumentRegistration orderby i.id descending select i).ToList();
        }
        public DocumentRegistration Read(int id)
        {
            return (from i in (new LibraryEntities()).DocumentRegistration where i.id == id select i).Single();
        }
        public void Delete(int id)
        {
            LibraryEntities db = new LibraryEntities();
            DeletedDocument d = new DeletedDocument();
            d.BookName = Read(id).BookName;
            d.CoverName = Read(id).CoverName;
            d.Date = Read(id).Date;
            d.Description = Read(id).Description;
            d.HelpNumber = Read(id).HelpNumber;
            d.Inventory = Read(id).Inventory;
            d.PartNumber = Read(id).PartNumber;
            d.Price = Read(id).Price;
            d.Publisher = Read(id).Publisher;
            d.Topic = Read(id).Topic;
            d.Writer = Read(id).Writer;
            db.DeletedDocument.Add(d);
            db.SaveChanges();
            var q = db.DocumentRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.DocumentRegistration.Remove(q.Single());
                db.SaveChanges();
            }
        }
        public string Update(int id, DocumentRegistration d)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.DocumentRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                DocumentRegistration dr = new DocumentRegistration();
                dr = q.Single();
                dr.BookName = d.BookName;
                dr.Writer = d.Writer;
                dr.Inventory = d.Inventory;
                dr.Publisher = d.Publisher;
                dr.CoverName = d.CoverName;
                dr.PartNumber = d.PartNumber;
                dr.Price = d.Price;
                dr.Date = d.Date;
                dr.Topic = d.Topic;
                dr.Description = d.Description;
                dr.HelpNumber = d.HelpNumber;
                db.SaveChanges();
                return "سند بروزرسانی شد";
            }
            return "";
        }
        public List<DocumentRegistration> Read(string Text)
        {
            return (from i in (new LibraryEntities()).DocumentRegistration where i.BookName.Contains(Text) || i.Writer.Contains(Text) || i.Publisher.Contains(Text) || i.Topic.Contains(Text) orderby i.id descending select i).ToList();
        }
        public bool Check(int id)
        {
            List<int> id1 = (from i in (new LibraryEntities()).BookLoan where i.doc_id == id select i.id).ToList();
            if (id1.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
