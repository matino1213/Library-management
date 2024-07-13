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
    public partial class AmanatKetab : Form
    {
        public AmanatKetab()
        {
            InitializeComponent();
        }
        int id;
        int id1;
        bool flag = false;
        bool flagg = false;

        private void AmanatKetab_Load(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = bla.Read();
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = bla.Read1();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bla.Read2();
            radioButton3_CheckedChanged(sender, e);
            txtSearchUser.Select();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            btnUserChoose.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = (int)dataGridView3.Rows[e.RowIndex].Cells[0].Value;
            btnDocChoose.Enabled = true;
            btnShowInfo.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bla.Read(txtSearchUser.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = bla.Read1(txtSearchDoc.Text);
        }
        int ID;
        private void button3_Click(object sender, EventArgs e)
        {
            btnUserChoose.Text = "کاربر " + id.ToString() + " انتخاب شد";
            flag = true;
            ID = id;
            errorProvider1.SetError(btnUserChoose, "");
            txtSearchDoc.Select();
        }
        int ID1;
        private void button4_Click(object sender, EventArgs e)
        {
            btnDocChoose.Text = "کتاب " + id1.ToString() + " انتخاب شد";
            flagg = true;
            ID1 = id1;
            mskDate.Select();
            mskDate.Text = DateTime.Now.ToString();
            mskReturnDate.Text = DateTime.Now.AddDays(14).ToString();
            errorProvider1.SetError(btnDocChoose, "");
        }
        private void ClearError()
        {
            errorProvider1.SetError(btnUserChoose, "");
            errorProvider1.SetError(btnDocChoose, "");
            errorProvider1.SetError(mskDate, "");
            errorProvider1.SetError(mskReturnDate, "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BlAmanatKetab blam = new BlAmanatKetab();
            if (!flag && !flag1)
            {
                ClearError();
                errorProvider1.SetError(btnUserChoose, "یک کاربر را انتخاب کنید");
            }
            else if (!flagg && !flag1)
            {
                ClearError();
                errorProvider1.SetError(btnDocChoose, "یک کتاب را انتخاب کنید");
            }
            else if (mskDate.Text.Length != 10)
            {
                ClearError();
                mskDate.Select();
                errorProvider1.SetError(mskDate, "تاریخ امانت را وارد کنید");
            }
            else if (mskReturnDate.Text.Length != 10)
            {
                ClearError();
                mskReturnDate.Select();
                errorProvider1.SetError(mskReturnDate, "تاریخ برگشت امانت را وارد کنید");
            }
            else if (!flag1 && int.Parse(blam.Read1(ID1).Inventory) < 1)
            {
                ClearError();
                lblError.Text = "کتاب موجود نیست";
            }
            else if (Convert.ToDateTime(mskDate.Text) >= Convert.ToDateTime(mskReturnDate.Text))
            {
                ClearError();
                errorProvider1.SetError(mskDate, "تاریخ ها را به درستی وارد کنید");
                errorProvider1.SetError(mskReturnDate, "تاریخ ها را به درستی وارد کنید");
            }
            else if (Convert.ToDateTime(mskDate.Text) < DateTime.Now.AddDays(-1))
            {
                ClearError();
                errorProvider1.SetError(mskReturnDate, "تاریخ تحویل برای گذشته است");
            }
            else if (!flag1)
            {
                if (blam.Read(ID).Status == "غیر فعال")
                {
                    ClearError();
                    DialogResult result;
                    result = MessageBox.Show("اعتبار کاربر به پایان رسیده است آیا مایل به تمدید اعتبار هستید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Tamdid t = new Tamdid(ID);
                        t.Show();
                    }
                }
                else
                {
                    ClearError();
                    BlAmanatKetab bla = new BlAmanatKetab();
                    string Name = bla.Read(ID).Name;
                    string BookName = bla.Read1(ID1).BookName;
                    BookLoan b = new BookLoan();
                    b.mem_id = ID;
                    b.doc_id = ID1;
                    b.Name = Name;
                    b.BookName = BookName;
                    b.Date = Convert.ToDateTime(mskDate.Text);
                    b.ReturnDate = Convert.ToDateTime(mskReturnDate.Text);
                    b.Description = txtDescription.Text;
                    b.Condition = "فعال";
                    bla.UpdateBookLoanMem(ID);
                    bla.UpdateBookLoanDoc(ID1);
                    MessageBox.Show(text: bla.Create(b));
                    Clear();
                    DocumentRegistration d = new DocumentRegistration();
                    d.Inventory = (Convert.ToInt32(bla.Read1(ID1).Inventory) - 1).ToString();
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = bla.Read1();
                    bla.Update(ID1, d);
                }
            }
            else
            {
                ClearError();
                BlAmanatKetab bla = new BlAmanatKetab();
                int x = bla.Read2(id2).doc_id;
                BookLoan b = new BookLoan();
                b.Date = Convert.ToDateTime(mskDate.Text);
                b.ReturnDate = Convert.ToDateTime(mskReturnDate.Text);
                b.Description = txtDescription.Text;
                b.Condition = "فعال";
                bla.UpdateBookLoanDoc(bla.Read2(id2).doc_id);
                bla.UpdateBookLoanMem(bla.Read2(id2).mem_id);
                MessageBox.Show(text: bla.Update2(id2, b));
                DocumentRegistration d = new DocumentRegistration();
                d.Inventory = (Convert.ToInt32(bla.Read1(x).Inventory) - 1).ToString();
                bla.Update(x, d);
                dataGridView1.Enabled = true;
                btnBookLoan.Text = "امانت کتاب";
                btnReserveBookLoan.Text = "امانت رزرو";
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                flag1 = false;
                btnReserve.Enabled = true;
                Clear();
            }

        }
        public void Clear()
        {
            ClearError();
            BlAmanatKetab bla = new BlAmanatKetab();
            btnUserChoose.Text = "انتخاب کاربر";
            btnDocChoose.Text = "انتخاب کتاب";
            btnUserChoose.Enabled = false;
            btnShowInfo.Enabled = false; ;
            mskDate.Text = "";
            mskReturnDate.Text = "";
            txtDescription.Text = "";
            txtSearchUser.Text = "";
            txtSearchDoc.Text = "";
            lblError.Text = "";
            btnDelete.Enabled = false;
            btnUserChoose.Enabled = false;
            btnDocChoose.Enabled = false;
            btnRecive.Enabled = false;
            btnReserveBookLoan.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read2();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bla.Read();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = bla.Read1();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            if (radioButton3.Checked)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read2(txtSearch.Text);
            }
            else if (radioButton1.Checked)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read2(txtSearch.Text, "فعال");
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read2(txtSearch.Text, "رزرو");
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskReturnDate.Select();
            }
        }

        private void maskedTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Select();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        static int id2;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id2 = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnDelete.Enabled = true;
            btnRecive.Enabled = true;
            btnReserveBookLoan.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            if (bla.Read2(id2).Condition == "غیر فعال" || bla.Read2(id2).Condition == "رزرو")
            {
                MessageBox.Show("لطفا یک امانت فعال را انتخاب نمایید");
            }
            else if (bla.Read2(id2).Condition == "جریمه")
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = Convert.ToDateTime(bla.Read2(id2).ReturnDate);
                TimeSpan ts = dt1.Subtract(dt2);
                int days = ts.Days;
                string day = days.ToString();
                DialogResult result;
                result = MessageBox.Show("آیا از دریافت امانت با " + day + " روز تاخیر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BookLoan b = new BookLoan();
                    b.Condition = "غیر فعال";
                    b.DateReceived = DateTime.Now;
                    MessageBox.Show(text: bla.Update1(id2, b));
                    DocumentRegistration d = new DocumentRegistration();
                    int i = bla.Read2(id2).doc_id;
                    int y = int.Parse(bla.Read1(i).Inventory);
                    d.Inventory = (y + 1).ToString();
                    bla.Update(i, d);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read2();
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = bla.Read1();
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("آیا از دریافت امانت مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BookLoan b = new BookLoan();
                    b.Condition = "غیر فعال";
                    b.DateReceived = DateTime.Now;
                    MessageBox.Show(text: bla.Update1(id2, b));
                    DocumentRegistration d = new DocumentRegistration();
                    int i = bla.Read2(id2).doc_id;
                    int y = int.Parse(bla.Read1(i).Inventory);
                    d.Inventory = (y + 1).ToString();
                    bla.Update(i, d);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read2();
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = bla.Read1();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            if (!flag)
            {
                ClearError();
                errorProvider1.SetError(btnUserChoose, "یک کاربر را انتخاب کنید");
            }
            else if (!flagg)
            {
                ClearError();
                errorProvider1.SetError(btnDocChoose, "یک کتاب را انتخاب کنید");
            }
            else if (int.Parse(bla.Read1(ID1).Inventory) != 0)
            {
                ClearError();
                lblError.Text = "کتاب موجود است";
            }
            else
            {
                ClearError();
                BookLoan b = new BookLoan();
                string Name = bla.Read(ID).Name;
                string BookName = bla.Read1(ID1).BookName;
                b.mem_id = ID;
                b.doc_id = ID1;
                b.Name = Name;
                b.BookName = BookName;
                b.Condition = "رزرو";
                bla.Create(b);
                Clear();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read2();
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = bla.Read1();
                MessageBox.Show("کتاب رزرو شد");
            }
        }
        bool flag1 = false;
        private void button7_Click(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            int x = bla.Read2(id2).doc_id;
            if (bla.Read2(id2).Condition != "رزرو")
            {
                MessageBox.Show("فیلد انتخابی شما جزء بخش رزرو ها نیست");
            }
            else if (int.Parse(bla.Read1(x).Inventory) == 0)
            {
                MessageBox.Show("کتاب موجود نمی باشد");
            }
            else if (!flag1)
            {
                mskDate.Text = DateTime.Now.ToString();
                mskReturnDate.Text = DateTime.Now.AddDays(14).ToString();
                mskDate.Select();
                dataGridView1.Enabled = false;
                btnBookLoan.Text = "امانت رزرو";
                btnReserve.Enabled = false;
                btnRecive.Enabled = false;
                btnDelete.Enabled = false;
                btnUserChoose.Enabled = false;
                btnDocChoose.Enabled = false;
                btnShowInfo.Enabled = false; ;
                btnReserveBookLoan.Text = "لغو";
                dataGridView2.Enabled = false;
                dataGridView3.Enabled = false;
                flag1 = true;
            }
            else
            {
                dataGridView1.Enabled = true;
                btnBookLoan.Text = "امانت کتاب";
                btnReserveBookLoan.Text = "امانت رزرو";
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                btnReserve.Enabled = true;
                flag1 = false;
                Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read3("فعال", "جریمه");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read3("رزرو");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            if (bla.Read2(id2).Condition == "فعال" || bla.Read2(id2).Condition == "جریمه")
            {
                MessageBox.Show("ابتدا امانت را غیر فعال کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("آیا از حذف امانت مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bla.Delete(id2);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read2();
                    Clear();
                    MessageBox.Show("امانت حذف شد");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage h = new HomePage();
            h.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read3("جریمه");
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

        private void button9_Click(object sender, EventArgs e)
        {
            ShowInformation s = new ShowInformation(id1);
            s.Show();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mskDate, "");
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mskReturnDate, "");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            DialogResult result;
            result = MessageBox.Show("بعد از بازنشانی جدول امانات ، تمام امانت ها و گزارش های موجود در برنامه حذف میشود. آیا از انجام این کار مطمعنید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (bla.CheckDelete())
                {
                    MessageBox.Show("!ابتدا تمام امانت های فعال و جریمه را غیر فعال نمایید","اخطار",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    bla.DeleteAll();
                    MessageBox.Show("بازنشانی جدول امانات با موفقیت انجام شد");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read2();
                }
            }
        }
    }
}
