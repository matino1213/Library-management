using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DlLogin
    {
        LibraryEntities db = new LibraryEntities();
        public byte Login(string username , string password)
        {
            if (db.Librarians.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.Librarians.Any(i => i.Log_UserName == username && i.Log_Password == password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        public List<Librarians> Read()
        {
            return ((new LibraryEntities()).Librarians.ToList());
        }
        public void FirstRun()
        {
            List<Librarians> l = (from i in (new LibraryEntities().Librarians) select i).ToList();
            if (l.Count() == 0)
            {
                Librarians lo = new Librarians();
                LibraryEntities db = new LibraryEntities();
                lo.Log_UserName = "a";
                lo.Log_Password = "123";
                db.Librarians.Add(lo);
                db.SaveChanges();
            }
        }
        public void update(bool b , string s)
        {
            log l = new log();
            LibraryEntities db = new LibraryEntities();
            var q = db.log.Where(i => i.id == 1);
            if (q.Count() == 1)
            {
                log bo = new log();
                bo = q.Single();
                bo.@bool = b;
                bo.@string = s;
                db.SaveChanges();
            }
        }
        public void update1(string s)
        {
            log l = new log();
            LibraryEntities db = new LibraryEntities();
            var q = db.log.Where(i => i.id == 1);
            if (q.Count() == 1)
            {
                log bo = new log();
                bo = q.Single();
                bo.username = s;
                db.SaveChanges();
            }
        }
        public log Readlog()
        {
            return (from i in (new LibraryEntities().log) where i.id == 1 select i).Single();
        }
    }
}
