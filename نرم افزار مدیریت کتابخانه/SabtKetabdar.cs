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
    public partial class SabtKetabdar : Form
    {
        public void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtPasswordAgain.Text = "";
        }
        public SabtKetabdar()
        {
            InitializeComponent();
        }

        private void SabtKetabdar_Load(object sender, EventArgs e)
        {
            txtUserName.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtUserName, "نام کتابدار را وارد کنید");
                txtUserName.Select();
            }
            else if (maskedTextBox1.Text.Trim().Length != 10)
            {
                errorProvider1.SetError(maskedTextBox1, "کد ملی را وارد نمایید");
            }
            else if (txtPassword.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPassword, "رمز عبور را وارد کنید");
                txtPassword.Select();
            }
            else if (txtPasswordAgain.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPasswordAgain, "تکرار رمز عبور را وارد کنید");
                txtPasswordAgain.Select();
            }
            else if (txtPassword.Text.Trim() != txtPasswordAgain.Text.Trim())
            {
                errorProvider1.SetError(txtPasswordAgain, "رمز عبور و تکرار آن یکی نیست");
                txtPasswordAgain.Text = "";
                txtPasswordAgain.Select();
            }
            else
            {
                BlSabtKetabdar bls = new BlSabtKetabdar();
                Librarians l = new Librarians();
                l.Log_UserName = txtUserName.Text.Trim();
                l.Log_Password = txtPassword.Text.Trim();
                l.NationalCode = maskedTextBox1.Text.Trim();
                MessageBox.Show(text: bls.Create(l));
                Clear();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maskedTextBox1.Select();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPasswordAgain.Select();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
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
                this.Close();
                HomePage h = new HomePage();
                h.Show();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage h = new HomePage();
            h.Show();
        }
        private bool dragging;
        private Point pointClicked;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUserName, "");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassword, "");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPasswordAgain, "");
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(maskedTextBox1, "");
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }
        }
    }
}
