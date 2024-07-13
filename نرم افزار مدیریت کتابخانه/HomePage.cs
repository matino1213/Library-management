using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace نرم_افزار_مدیریت_کتابخانه
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        string uName;
        public HomePage(string UserName)
        {
            InitializeComponent();
            uName = UserName;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            btnBookLoan.Select();
            lblUserName.Text = (from i in (new LibraryEntities().log) where i.id == 1 select i.username).Single();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ثبتکاربرجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SabtKetabdar sk = new SabtKetabdar();
            sk.Show();
            this.Close();
        }

        private void ویرایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirayeshKetabdar vk = new VirayeshKetabdar();
            vk.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AfzodanSanad a = new AfzodanSanad();
            a.Show();
            this.Close();
        }

        private void افزودنسندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfzodanSanad a = new AfzodanSanad();
            a.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AzaKetabkhane ak = new AzaKetabkhane();
            ak.Show();
            this.Close();
        }

        private void اعضاکتابخانهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AzaKetabkhane ak = new AzaKetabkhane();
            ak.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TamdidOzviat to = new TamdidOzviat();
            to.Show();
            this.Close();
        }

        private void تمدیداعتباراعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TamdidOzviat to = new TamdidOzviat();
            to.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AmanatKetab a = new AmanatKetab();
            a.Show();
            this.Close();
        }

        private void امانتسندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmanatKetab a = new AmanatKetab();
            a.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("آیا از بستن برنامه مطمئنید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                this.Close();
                AmanatKetab a = new AmanatKetab();
                a.Show();
                return true;
            }
            else if (keyData == Keys.F2)
            {
                this.Close();
                TamdidOzviat t = new TamdidOzviat();
                t.Show();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                this.Close();
                AzaKetabkhane a = new AzaKetabkhane();
                a.Show();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                this.Close();
                AfzodanSanad a = new AfzodanSanad();
                a.Show();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                DialogResult result;
                result = MessageBox.Show("آیا از بستن برنامه مطمئنید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (keyData == (Keys.Control | Keys.Alt | Keys.D | Keys.E))
            {
                this.Close();
                DeletedItems d = new DeletedItems();
                d.Show();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool dragging;
        private Point pointClicked;
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // turn drag mode on and store the point clicked.
                dragging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point pointMoveTo;
                // Find the current mouse position in screen coordinates.
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                // Compensate for the position the control was clicked.
                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                // Move the form.
                this.Location = pointMoveTo;
            }
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void ثبتکلاسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SabtClass s = new SabtClass();
            s.Show();
        }

        private void ثبتدانشآموزانهرکلاسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SabtDaneshamoz s = new SabtDaneshamoz();
            s.Show();
        }

        private void گزارشکتابهایبرترToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ReportDoc r = new ReportDoc();
            r.Show();
        }

        private void گزارشنفراتبرترToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ReportMem r = new ReportMem();
            r.Show();
        }

        private void گزارشکلاسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ReportClass r = new ReportClass();
            r.Show();
        }

        private void راهنماToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }
    }
}
