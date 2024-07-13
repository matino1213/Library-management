using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BlReportDoc
    {
        DlReportDoc dlr = new DlReportDoc();
        public List<BookReport> Read()
        {
            return dlr.Read();
        }
        public void UpdateByDate(DateTime d1, DateTime d2)
        {
            dlr.UpdateByDate(d1, d2);
        }
        public void UpdateAll()
        {
            dlr.UpdateAll();
        }
        public List<BookReport> Read(string text)
        {
            return dlr.Read(text);
        }
        public BookReport Read(int id)
        {
            return dlr.Read(id);
        }
        public int BookLoan()
        {
            return dlr.BookLoan();
        }
    }
}
