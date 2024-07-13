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
    public partial class VirayeshKetabdar : Form
    {
        public VirayeshKetabdar()
        {
            InitializeComponent();
        }
        private void VirayeshKetabdar_Load(object sender, EventArgs e)
        { 
            lblUserName.Text = (from i in (new LibraryEntities().log) where i.id == 1 select i.username).Single();
            txtPas.Select();
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

        private void btnUpdatePas_Click(object sender, EventArgs e)
        {
            if (txtPas.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPas, "رمز قبلی را وارد نمایید");
                txtPas.Select();
            }
            else if (txtNewPas.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtNewPas, "رمز جدید را وارد نمایید");
                txtNewPas.Select();
            }
            else if (txtNewPasAgain.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtNewPasAgain, "تکرار رمز جدید را وارد نمایید");
                txtNewPasAgain.Select();
            }
            else
            {
                BlVirayeshKetebdar blv = new BlVirayeshKetebdar();
                MessageBox.Show(text: blv.UpdatePas(txtPas.Text, txtNewPas.Text, txtNewPasAgain.Text));
                Clear();
            }
        }
        private void Clear()
        {
            txtNewPas.Text = "";
            txtNewPasAgain.Text = "";
            txtPas.Text = "";
            mskNCode.Text = "";
        }

        private void txtPas_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPas, "");
        }

        private void txtNewPas_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNewPas, "");
        }

        private void txtNewPasAgain_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNewPasAgain, "");
        }

        private void mskNCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mskNCode, "");
        }

        private void btnUpdateNCode_Click(object sender, EventArgs e)
        {
            BlVirayeshKetebdar blv = new BlVirayeshKetebdar();
            if (mskNCode.Text.Trim().Length !=10)
            {
                errorProvider1.SetError(mskNCode, "کد ملی را بدرستی وارد نمایید");
            }
            else
            {
                MessageBox.Show(text: blv.UpdateNCode(mskNCode.Text));
                Clear();
            }
        }

        private void txtPas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPas.Select();
            }
        }

        private void txtNewPas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPasAgain.Select();
            }
        }

        private void txtNewPasAgain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdatePas_Click(sender, e);
            }
        }

        private void mskNCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdateNCode_Click(sender, e);
            }
        }
    }
}
