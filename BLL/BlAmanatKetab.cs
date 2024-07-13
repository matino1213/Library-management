using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BlAmanatKetab
    {
        DlAmanatKetab dlm = new DlAmanatKetab();
        public List<MemberRegistration> Read()
        {
            return dlm.Read();
        }
        public List<DocumentRegistration> Read1()
        {
            return dlm.Read1();
        }
        public MemberRegistration Read(int id)
        {
            return dlm.Read(id);
        }
        public List<MemberRegistration> Read(string Text)
        {
            return dlm.Read(Text);
        }
        public DocumentRegistration Read1(int id)
        {
            return dlm.Read1(id);
        }
        public List<DocumentRegistration> Read1(string Text)
        {
            return dlm.Read1(Text);
        }
        public string Update(int id, DocumentRegistration d)
        {
            return dlm.Update(id, d);
        }
        public string Create(BookLoan b)
        {
            return dlm.Create(b);
        }
        public List<BookLoan> Read2()
        {
            dlm.Check();
            return dlm.Read2();
        }
        public List<BookLoan> Read2(string Text)
        {
            return dlm.Read2(Text);
        }
        public List<BookLoan> Read3(string Text)
        {
            return dlm.Read3(Text);
        }
        public List<BookLoan> Read3(string Text, string text)
        {
            return dlm.Read3(Text, text);
        }
        public string Update1(int id, BookLoan b)
        {
            return dlm.Update1(id, b);
        }
        public BookLoan Read2(int id)
        {
            return dlm.Read2(id);
        }
        public List<BookLoan> Read2(string Text, string t)
        {
            return dlm.Read2(Text, t);
        }
        public string Update2(int id, BookLoan b)
        {
            return dlm.Update2(id, b);
        }
        public void Delete(int id)
        {
            dlm.Delete(id);
        }
        public string Update2(int id, MemberRegistration m)
        {
            return dlm.Update2(id, m);
        }
        public void UpdateBookLoanMem(int id)
        {
            dlm.UpdateBookLoanMem(id);
        }
        public void UpdateBookLoanDoc(int id)
        {
            dlm.UpdateBookLoanDoc(id);
        }
        public bool CheckDelete()
        {
            return dlm.ChechDelete();
        }
        public void DeleteAll()
        {
            dlm.DeleteAll();
        }
    }
}
