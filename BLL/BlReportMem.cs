using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BlReportMem
    {
        DlReportMem dlr = new DlReportMem();
        public List<UserReport> Read()
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
        public List<UserReport> Read(string text, string t)
        {
            return dlr.Read(text, t);
        }
        public int BookLoan()
        {
            return dlr.BookLoan();
        }
        public List<UserReport> ReadFilter(string text)
        {
            return dlr.ReadFilter(text);
        }
        public List<UserReport> ReadClass(string text)
        {
            return dlr.ReadClass(text);
        }
        public List<Classroom> Class()
        {
            return dlr.Class();
        }
    }
}
