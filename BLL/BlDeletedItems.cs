using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BlDeletedItems
    {
        DlDeletedItems dld = new DlDeletedItems();
        public List<DeletedBookLoan> ReadBookLoan()
        {
            return dld.ReadBookLoan();
        }
        public List<DeletedDocument> ReadDoc()
        {
            return dld.ReadDoc();
        }
        public List<DeletedMembers> ReadMem()
        {
            return dld.ReadMem();
        }
        public DeletedBookLoan ReadBookLoan(int id)
        {
            return dld.ReadBookLoan(id);
        }
        public DeletedDocument ReadDoc(int id)
        {
            return dld.ReadDoc(id);
        }
        public DeletedMembers ReadMem(int id)
        {
            return dld.ReadMem(id);
        }
        public string CreateDoc(DocumentRegistration d)
        {
            return dld.CreateDoc(d);
        }
        public string CreateMem(MemberRegistration m)
        {
            return dld.CreateMem(m);
        }
        public void DeleteBookLoan(int id)
        {
            dld.DeleteBookLoan(id);
        }
        public void DeleteDoc(int id)
        {
            dld.DeleteDoc(id);
        }
        public void DeleteMem(int id)
        {
            dld.DeleteMem(id);
        }
        public List<DeletedBookLoan> ReadBookLoan(string text)
        {
            return dld.ReadBookLoan(text);
        }
        public List<DeletedDocument> ReadDoc(string text)
        {
            return dld.ReadDoc(text);
        }
        public List<DeletedMembers> ReadMem(string text)
        {
            return dld.ReadMem(text);
        }
    }
}
