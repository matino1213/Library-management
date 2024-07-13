using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BlLogin
    {
        DlLogin dll = new DlLogin();
        public byte Login(string username, string password)
        {
            return dll.Login(username, password);
        }
        public List<Librarians> Read()
        {
            return dll.Read();
        }
        public void FirstRun()
        {
            dll.FirstRun();
        }
        public void update(bool b, string s)
        {
            dll.update(b, s);
        }
        public log Readlog()
        {
            return dll.Readlog();
        }
        public void update1(string s)
        {
            dll.update1(s);
        }
    }
}
