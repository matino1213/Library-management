using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class DlAzaKetabkhane
    {
        //متد تکراری نبودن اعضا
        public bool Exist(MemberRegistration m,int id)
        {
            LibraryEntities db = new LibraryEntities();
            foreach (var item in db.MemberRegistration)
            {
                if (item.id == id)
                {
                    continue;
                }
                else if (m.NationalCode == item.NationalCode)
                {
                    return true;
                }
            }
            return false;
        }
        //متد ساخت عضو جدید
        public string Create(MemberRegistration m)
        {
            if (!Exist(m,0))
            {
                LibraryEntities db = new LibraryEntities();
                db.MemberRegistration.Add(m);
                db.SaveChanges();
                return "عضو جدید ثبت شد";
            }
            return "کاربر موجود است";
        }
        //متد خواندن اعضا
        public List<MemberRegistration> Read()
        {
            return (from i in (new LibraryEntities()).MemberRegistration orderby i.id descending select i).ToList();
        }
        //متد انتخاب اعضا بر اساس ای دی
        public MemberRegistration Read(int id)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.id == id select i).Single();
        }
        //متد حذف اعضا
        public void Delete(int id)
        {
            LibraryEntities db = new LibraryEntities();
            DeletedMembers d = new DeletedMembers();
            d.ClassName = Read(id).ClassName;
            d.Classroom_id = Read(id).Classroom_id;
            d.CompletionDate = Read(id).CompletionDate;
            d.Credit = Read(id).Credit;
            d.Date = Read(id).Date;
            d.Name = Read(id).Name;
            d.NationalCode = Read(id).NationalCode;
            d.OtherSpecifications = Read(id).OtherSpecifications;
            d.PhoneNumber = Read(id).PhoneNumber;
            d.Status = Read(id).Status;
            d.UserType = Read(id).UserType;
            db.DeletedMembers.Add(d);
            db.SaveChanges();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.MemberRegistration.Remove(q.Single());
                db.SaveChanges();
            }
        }
        //متد ویرایش اعضا
        public string Update(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration mr = new MemberRegistration();
                mr = q.Single();
                mr.Name = m.Name;
                mr.PhoneNumber = m.PhoneNumber;
                mr.NationalCode = m.NationalCode;
                mr.Status = m.Status;
                mr.Credit = m.Credit;
                mr.OtherSpecifications = m.OtherSpecifications;
                mr.ClassName = m.ClassName;
                mr.UserType = m.UserType;
                mr.Classroom_id = m.Classroom_id;
                if (!Exist(mr, id))
                {
                    db.SaveChanges();
                    return "عضو بروزرسانی شد";
                }
                else
                {
                    return "عضو موجود است";
                }
            }
            return "";
        }
        //متد خواندن برای جستجو در جدول
        public List<MemberRegistration> Read(string Text)
        {
            return (from i in (new LibraryEntities()).MemberRegistration where i.Name.Contains(Text) || i.PhoneNumber.Contains(Text) || i.NationalCode.Contains(Text) orderby i.id descending select i).ToList();
        }
        //این متد برای متد چک کردن است که اعتبار اعضا رو بروزرسانی کنه
        public string UpdateChech(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration me = new MemberRegistration();
                me = q.Single();
                me.Credit = m.Credit;
                db.SaveChanges();
                return "";
            }
            return "ERROR";
        }
        //این متد برای متد چک است که اعضایی که اعتبارشان تمام شده رو غیرفعال کنه
        public string UpdateChech1(int id, MemberRegistration m)
        {
            LibraryEntities db = new LibraryEntities();
            var q = db.MemberRegistration.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                MemberRegistration me = new MemberRegistration();
                me = q.Single();
                me.Credit = m.Credit;
                me.Status = m.Status;
                db.SaveChanges();
                return "";
            }
            return "ERROR";
        }
        //این متد چک میکنه که چقدر از اعتبار اعضا باقی مونده
        public void Check()
        {
            List<int> id = (from i in (new LibraryEntities()).MemberRegistration where i.Status == "فعال" select i.id).ToList();
            foreach (var item in id)
            {
                //این بخش کد برای محاسبه تعداد روز های باقی مونده از اعتبار کاربر هست
                MemberRegistration m = new MemberRegistration();
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = Convert.ToDateTime(Read(item).CompletionDate);
                TimeSpan ts = dt2.Subtract(dt1);
                int days = ts.Days + 2;
                if (days > 0)
                {
                    m.Credit = days;
                    UpdateChech(item, m);
                }
                else
                {
                    m.Credit = 0;
                    m.Status = "غیرفعال";
                    m.Date = null;
                    m.CompletionDate = null;
                    UpdateChech1(item, m);
                }
            }
        }
        //این متد برای زمانی هست که میخواهیم یک کاربر ار حذف کنیم و اگر در جدول امانات امانتی داشته باشه اول باید آنها را حذف کنیم در غیر این صورت برنامه ارور امیدهد
        public bool CheckExist(int id)
        {
            List<int> id1 = (from i in (new LibraryEntities()).BookLoan where i.mem_id == id select i.id).ToList();
            if (id1.Count() > 0)
            {
                return true;
            }
            return false;
        }
        //متد خواندن کلاس ها
        public List<Classroom> ReadClass()
        {
            return ((new LibraryEntities()).Classroom).ToList();
        }
    }
}
