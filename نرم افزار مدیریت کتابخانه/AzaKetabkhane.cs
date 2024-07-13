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
    public partial class AzaKetabkhane : Form
    {
        public AzaKetabkhane()
        {
            InitializeComponent();
        }
        private void AzaKetabkhane_Load(object sender, EventArgs e)
        {
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            txtName.Select();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bla.Read();
            btnShowInformation.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void Clear()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCredit.Text = "";
            mskNationalCode.Text = "";
            mskPhoneNumber.Text = "";
            cmbCondition.Text = "";
            cmbUserType.Text = "";
            cmbCondition.Text = "";
            cmbUserType.Text = "";
            cmbClassName.DataSource = null;
            cmbClassName.Text = "";
            cmbClassName.Enabled = false;
            txtName.Select();
        }
        bool flag = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0 )
            {
                errorProvider1.SetError(txtName, "نام و نام خانوادگی را وارد نمایید");
            }
            else if (cmbCondition.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(cmbCondition, "وضعیت را وارد نمایید");
            }
            else if (txtCredit.Text.Trim().Length == 0 && int.Parse(txtCredit.Text) < 1)
            {
                errorProvider1.SetError(txtCredit, "اعتبار/روز را به درستی وارد نمایید");
            }
            else if (cmbUserType.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(cmbUserType, "نوع کاربر را مشخص نمایید");
            }
            else if (!flag)
            {
                BlAzaKetabkhane bla = new BlAzaKetabkhane();
                MemberRegistration m = new MemberRegistration();
                m.Name = txtName.Text.Trim();
                m.PhoneNumber = mskPhoneNumber.Text;
                m.NationalCode = mskNationalCode.Text;
                m.Status = cmbCondition.Text;
                m.Credit = Convert.ToInt32(txtCredit.Text.Trim());
                m.OtherSpecifications = txtDescription.Text.Trim();
                m.UserType = cmbUserType.Text;
                m.BookLoan = 0;
                if (cmbUserType.Text == "دانش آموز")
                {
                    m.Classroom_id = int.Parse(cmbClassName.SelectedValue.ToString());
                    m.ClassName = cmbClassName.Text;
                }
                if (cmbCondition.Text == "فعال")
                {
                    m.Date = DateTime.Now;
                    m.CompletionDate = DateTime.Now.AddDays(int.Parse(txtCredit.Text.Trim()));
                }
                MessageBox.Show(text: bla.Create(m));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read();
                Clear();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("آیا از ویرایش کاربر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    MemberRegistration m = new MemberRegistration();
                    BlAzaKetabkhane bla = new BlAzaKetabkhane();
                    m.Name = txtName.Text.Trim();
                    m.PhoneNumber = mskPhoneNumber.Text;
                    m.NationalCode = mskNationalCode.Text;
                    m.Status = cmbCondition.Text;
                    m.Credit = Convert.ToInt32(txtCredit.Text.Trim());
                    m.OtherSpecifications = txtDescription.Text.Trim();
                    m.UserType = cmbUserType.Text;
                    if (cmbUserType.Text == "دانش آموز")
                    {
                        m.Classroom_id = int.Parse(cmbClassName.SelectedValue.ToString());
                        m.ClassName = cmbClassName.Text;
                    }
                    if (cmbCondition.Text == "فعال")
                    {
                        m.Date = DateTime.Now;
                        m.CompletionDate = DateTime.Now.AddDays(int.Parse(txtCredit.Text.Trim()));
                    }
                    MessageBox.Show(text: bla.Update(id, m));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    Clear();
                    flag = false;
                    btnRegister.Text = "ثبت عضو (Ctrl + S)";
                    btnUpdate.Text = "ویرایش";
                }
                else if (result == DialogResult.No)
                {
                    flag = false;
                    btnRegister.Text = "ثبت عضو (Ctrl + S)";
                    btnUpdate.Text = "ویرایش";
                    Clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                flag = true;
                btnRegister.Text = "بروزرسانی عضو (Ctrl + S)";
                btnUpdate.Text = "لغو";
                MemberRegistration m = new MemberRegistration();
                BlAzaKetabkhane bla = new BlAzaKetabkhane();
                m = bla.Read(id);
                txtName.Text = m.Name;
                mskPhoneNumber.Text = m.PhoneNumber;
                mskNationalCode.Text = m.NationalCode;
                cmbCondition.Text = m.Status;
                txtDescription.Text = m.OtherSpecifications;
                txtCredit.Text = (m.Credit).ToString();
                cmbUserType.Text = m.UserType;
                cmbClassName.Text = m.ClassName;
            }
            else
            {
                flag = false;
                btnRegister.Text = "ثبت عضو (Ctrl + S)";
                btnUpdate.Text = "ویرایش";
                Clear();
            }
        }
        int id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnShowInformation.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            DialogResult result;
            result = MessageBox.Show("آیا از حذف کاربر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (bla.CheckExist(id))
                {
                    MessageBox.Show("ابتدا رکورد های مربوط به این کاربر را در بخش امانت کتاب حذف نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bla.Delete(id);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    MessageBox.Show("کاربر حذف شد");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemberRegistration m = new MemberRegistration();
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            m = bla.Read(id);
            txtName.Text = m.Name;
            mskPhoneNumber.Text = m.PhoneNumber;
            mskNationalCode.Text = m.NationalCode;
            cmbCondition.Text = m.Status;
            txtDescription.Text = m.OtherSpecifications;
            txtCredit.Text = (m.Credit).ToString();
            cmbUserType.Text = m.UserType;
            cmbClassName.Text = m.ClassName;
            cmbClassName.Enabled = false;
            cmbUserType.Enabled = false;
            btnRegister.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtName.Enabled = false;
            txtDescription.Enabled = false;
            txtCredit.Enabled = false;
            mskNationalCode.Enabled = false;
            mskPhoneNumber.Enabled = false;
            cmbCondition.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            cmbUserType.Enabled = true;
            btnRegister.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            txtCredit.Enabled = true;
            mskNationalCode.Enabled = true;
            mskPhoneNumber.Enabled = true;
            cmbCondition.Enabled = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read(txtSearch.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUserType.Select();
            }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Select();
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskPhoneNumber.Select();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbCondition.Text == "فعال")
                {
                    txtCredit.Select();
                }
                else
                {
                    mskNationalCode.Select();
                }
                
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskNationalCode.Select();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCondition.Text == "فعال")
            {
                txtCredit.Text = "";
                txtCredit.Enabled = true;
            }
            else if (cmbCondition.Text == "غیر فعال")
            {
                txtCredit.Enabled = false;
                txtCredit.Text = "0";
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
            else if (keyData == (Keys.Control | Keys.S))
            {
                if (txtName.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtName, "نام و نام خانوادگی را وارد نمایید");
                }
                else if (cmbCondition.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(cmbCondition, "وضعیت را وارد نمایید");
                }
                else if (txtCredit.Text.Trim().Length == 0 && int.Parse(txtCredit.Text) < 1)
                {
                    errorProvider1.SetError(txtCredit, "اعتبار/روز را به درستی وارد نمایید");
                }
                else if (cmbUserType.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(cmbUserType, "نوع کاربر را مشخص نمایید");
                }
                else if (!flag)
                {
                    BlAzaKetabkhane bla = new BlAzaKetabkhane();
                    MemberRegistration m = new MemberRegistration();
                    m.Name = txtName.Text.Trim();
                    m.PhoneNumber = mskPhoneNumber.Text;
                    m.NationalCode = mskNationalCode.Text;
                    m.Status = cmbCondition.Text;
                    m.Credit = Convert.ToInt32(txtCredit.Text.Trim());
                    m.OtherSpecifications = txtDescription.Text.Trim();
                    m.UserType = cmbUserType.Text;
                    m.BookLoan = 0;
                    if (cmbUserType.Text == "دانش آموز")
                    {
                        m.Classroom_id = int.Parse(cmbClassName.SelectedValue.ToString());
                        m.ClassName = cmbClassName.Text;
                    }
                    if (cmbCondition.Text == "فعال")
                    {
                        m.Date = DateTime.Now;
                        m.CompletionDate = DateTime.Now.AddDays(int.Parse(txtCredit.Text.Trim()));
                    }
                    MessageBox.Show(text: bla.Create(m));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    Clear();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("آیا از ویرایش کاربر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        MemberRegistration m = new MemberRegistration();
                        BlAzaKetabkhane bla = new BlAzaKetabkhane();
                        m.Name = txtName.Text.Trim();
                        m.PhoneNumber = mskPhoneNumber.Text;
                        m.NationalCode = mskNationalCode.Text;
                        m.Status = cmbCondition.Text;
                        m.Credit = Convert.ToInt32(txtCredit.Text.Trim());
                        m.OtherSpecifications = txtDescription.Text.Trim();
                        m.UserType = cmbUserType.Text;
                        if (cmbUserType.Text == "دانش آموز")
                        {
                            m.Classroom_id = int.Parse(cmbClassName.SelectedValue.ToString());
                            m.ClassName = cmbClassName.Text;
                        }
                        if (cmbCondition.Text == "فعال")
                        {
                            m.Date = DateTime.Now;
                            m.CompletionDate = DateTime.Now.AddDays(int.Parse(txtCredit.Text.Trim()));
                        }
                        MessageBox.Show(text: bla.Update(id, m));
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bla.Read();
                        Clear();
                        flag = false;
                        btnRegister.Text = "ثبت عضو (Ctrl + S)";
                        btnUpdate.Text = "ویرایش";
                    }
                    else if (result == DialogResult.No)
                    {
                        flag = false;
                        btnRegister.Text = "ثبت عضو (Ctrl + S)";
                        btnUpdate.Text = "ویرایش";
                        Clear();
                    }
                }
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
            errorProvider1.SetError(txtName, "");
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read(txtName.Text);
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mskPhoneNumber, "");
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mskNationalCode, "");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCredit, "");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbCondition, "");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            SabtClass s = new SabtClass(true);
            s.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbUserType, "");
            BlAzaKetabkhane bla = new BlAzaKetabkhane();
            if (cmbUserType.Text == "دانش آموز")
            {
                cmbClassName.DataSource = bla.ReadClass();
                cmbClassName.DisplayMember = "ClassName";
                cmbClassName.ValueMember = "id";
                cmbClassName.Enabled = true;
            }
            else
            {
                cmbClassName.DataSource = null;
                cmbClassName.Text = "";
                cmbClassName.Enabled = false;
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbUserType.Text == "دانش آموز")
                {
                    cmbClassName.Select();
                }
                else
                {
                    cmbCondition.Select();
                }
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCondition.Select();
            }
        }
    }
}
