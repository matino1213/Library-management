using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace نرم_افزار_مدیریت_کتابخانه
{
    public partial class SabtClass : Form
    {
        public SabtClass()
        {
            InitializeComponent();
        }
        bool x = false;
        public SabtClass(bool a)
        {
            InitializeComponent();
            x = a;
        }

        private void SabtClass_Load(object sender, EventArgs e)
        {
            BlSabtClass bls = new BlSabtClass();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bls.Read();
            txtClassName.Select();
        }
        int id;
        bool flag = false;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void Clear()
        {
            txtClassName.Text = "";
            txtClassGrade.Text = "";
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BlSabtClass bls = new BlSabtClass();
            if (txtClassName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtClassName, "نام کلاس را وارد نمایید");
            }
            else if (!flag)
            {
                Classroom c = new Classroom();
                c.ClassName = txtClassName.Text;
                c.ClassGrade = txtClassGrade.Text;
                MessageBox.Show(text: bls.Create(c));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.Read();
                Clear();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("آیا از ویرایش کلاس مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Classroom c = new Classroom();
                    c.ClassName = txtClassName.Text;
                    c.ClassGrade = txtClassGrade.Text;
                    MessageBox.Show(text: bls.Update(id, c));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bls.Read();
                    Clear();
                    btnRegister.Text = "ثبت";
                    btnUpdate.Text = "ویرایش";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BlSabtClass bls = new BlSabtClass();
            if (!flag)
            {
                dataGridView1.Enabled = false;
                txtClassName.Text = bls.Read(id).ClassName;
                txtClassGrade.Text = bls.Read(id).ClassGrade;
                btnDelete.Enabled = false;
                btnUpdate.Text = "لغو";
                btnRegister.Text = "ثبت ویرایش";
                flag = true;
            }
            else
            {
                flag = false;
                Clear();
                btnRegister.Text = "ثبت";
                btnUpdate.Text = "ویرایش";
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.Read();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("آیا از ویرایش کاربر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                BlSabtClass bls = new BlSabtClass();
                bls.Delete(id);
                MessageBox.Show("کلاس با موفقیت حذف شد","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!x)
            {
                this.Close();
                HomePage h = new HomePage();
                h.Show();
            }
            else
            {
                this.Close();
                AzaKetabkhane a = new AzaKetabkhane();
                a.Show();
            }
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
                if (!x)
                {
                    this.Close();
                    HomePage h = new HomePage();
                    h.Show();
                }
                else
                {
                    this.Close();
                    AzaKetabkhane a = new AzaKetabkhane();
                    a.Show();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
