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
    public partial class TamdidOzviat : Form
    {
        public TamdidOzviat()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            txtInvertory.Text = "";
        }
        bool flag = false;
        int id;
        private void TamdidOzviat_Load(object sender, EventArgs e)
        {
            BlTamdidOzviat blt = new BlTamdidOzviat();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = blt.Read();
            btnTamdid.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtInvertory.Text) < 0)
            {
                errorProvider1.SetError(txtInvertory, "تمدید عضویت را به درستی وارد نمایید");
            }
            else if (!flag)
            {
                BlTamdidOzviat blt = new BlTamdidOzviat();
                MemberRegistration m = new MemberRegistration();
                m = blt.Read(id);
                textBox2.Text = m.Name;
                textBox3.Text = m.NationalCode;
                btnTamdid.Text = "ثبت تمدید عضویت";
                flag = true;
                txtInvertory.Enabled = true;
                txtInvertory.Text = "";
                txtInvertory.Select();
            }
            else
            {
                flag = false;
                btnTamdid.Text = "تمدید عضویت";
                BlTamdidOzviat blt = new BlTamdidOzviat();
                MemberRegistration m = new MemberRegistration();
                m.Credit = Convert.ToInt32(txtInvertory.Text) + blt.Read(id).Credit - 1;
                m.Status = "فعال";
                m.Date = DateTime.Now;
                m.CompletionDate = DateTime.Now.AddDays(Convert.ToInt32(txtInvertory.Text) + blt.Read(id).Credit - 1);
                MessageBox.Show(text: blt.Update(id, m));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blt.Read();
                txtInvertory.Enabled = false;
                txtInvertory.Text = "0";
                Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnTamdid.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BlTamdidOzviat blt = new BlTamdidOzviat();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blt.Read(txtSearch.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BlTamdidOzviat blt = new BlTamdidOzviat();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blt.Read(txtSearch.Text);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtInvertory, "");
        }
    }
}
