using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace نرم_افزار_مدیریت_کتابخانه
{
    public partial class AddDate : Form
    {
        public AddDate()
        {
            InitializeComponent();
        }
        public AddDate(byte b)
        {
            flag = b;
            InitializeComponent();
        }
        byte flag;
        private void button8_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.Close();
                ReportDoc r = new ReportDoc();
                r.Show();
            }
            else if (flag == 2)
            {
                this.Close();
                ReportMem r = new ReportMem();
                r.Show();
            }
            else if (flag == 3)
            {
                this.Close();
                ReportClass r = new ReportClass();
                r.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mskd1.Text.Trim().Length == 10 && mskd2.Text.Trim().Length == 10)
            {
                DateTime D1 = Convert.ToDateTime(mskd1.Text);
                DateTime D2 = Convert.ToDateTime(mskd2.Text);
                if (D1 < D2)
                {
                    if (flag == 1)
                    {
                        DateTime d1 = Convert.ToDateTime(mskd1.Text);
                        DateTime d2 = Convert.ToDateTime(mskd2.Text);
                        this.Close();
                        ReportDoc r = new ReportDoc(d1, d2);
                        r.Show();
                    }
                    else if (flag == 2)
                    {
                        DateTime d1 = Convert.ToDateTime(mskd1.Text);
                        DateTime d2 = Convert.ToDateTime(mskd2.Text);
                        this.Close();
                        ReportMem r = new ReportMem(d1, d2);
                        r.Show();
                    }
                    else if (flag == 3)
                    {
                        DateTime d1 = Convert.ToDateTime(mskd1.Text);
                        DateTime d2 = Convert.ToDateTime(mskd2.Text);
                        this.Close();
                        ReportClass r = new ReportClass(d1, d2);
                        r.Show();
                    }
                }
                else
                {
                    MessageBox.Show("تاریخ ها را به درستی وارد نمایید");
                }
            }
            else
            {
                MessageBox.Show("تاریخ ها را به درستی وارد نمایید");
            }
        }

        private void AddDate_Load(object sender, EventArgs e)
        {
            mskd1.Select();
        }

        private void mskd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskd2.Select();
            }
        }

        private void mskd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
