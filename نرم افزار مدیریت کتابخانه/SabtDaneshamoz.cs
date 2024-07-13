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
    public partial class SabtDaneshamoz : Form
    {
        public SabtDaneshamoz()
        {
            InitializeComponent();
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

        private void SabtDaneshamoz_Load(object sender, EventArgs e)
        {
            BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bls.Read();
            cmbChooseClass.DataSource = bls.ReadClass();
            cmbChooseClass.DisplayMember = "ClassName";
            cmbChooseClass.ValueMember = "id";
        }
        int id;
        bool flag = false;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idd = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnSelect.Enabled = true;
        }
        int idd;
        private void button2_Click(object sender, EventArgs e)
        {
            btnSelect.Text = "دانش آموز " + idd.ToString() + " انتخاب شد";
            id = idd;
            flag = true;
            errorProvider1.SetError(btnSelect, "");
            cmbChooseClass.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                errorProvider1.SetError(btnSelect, "یک دانش آموز را انتخاب نمایید");
            }
            else
            {
                MemberRegistration m = new MemberRegistration();
                BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
                m.ClassName = cmbChooseClass.Text;
                m.Classroom_id = int.Parse(cmbChooseClass.SelectedValue.ToString());
                MessageBox.Show(text: bls.Update(id, m));
                flag = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.Read();
                btnSelect.Enabled = false;
                btnSelect.Text = "انتخاب دانش آموز";
            }
        }
        bool flag1 = false;
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (!flag1)
            {
                BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.Read(cmbSearch.Text);
            }
            else if (flag1)
            {
                BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.ReadbyClassName(cmbSearch.Text);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            flag1 = false;
            cmbSearch.DropDownStyle = ComboBoxStyle.Simple;
            BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
            dataGridView1.DataSource = null;
            cmbSearch.Text = "";
            dataGridView1.DataSource = bls.Read(cmbSearch.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            flag1 = true;
            cmbSearch.DataSource = null;
            cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
            cmbSearch.DataSource = bls.ReadClass();
            cmbSearch.DisplayMember = "ClassName";
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bls.ReadbyClassName(cmbSearch.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("آیا از بازنشانی تمام کلاس ها مطمعنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                BlSabtDaneshamoz bls = new BlSabtDaneshamoz();
                MessageBox.Show(text: bls.Reset());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bls.Read();
            }
        }
    }
}
