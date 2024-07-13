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
    public partial class AfzodanSanad : Form
    {
        public AfzodanSanad()
        {
            InitializeComponent();
        }
        bool flag = false;
        int id;

        private void AfzodanSanad_Load(object sender, EventArgs e)
        {
            BlAfzodanSanad bla = new BlAfzodanSanad();
            txtBookName.Select();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bla.Read();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnShowInformation.Enabled = false;
        }
        public void Clear()
        {
            txtBookName.Text = "";
            txtWriter.Text = "";
            txtInventory.Text = "";
            txtCoverName.Text = "";
            txtPartNumber.Text = "";
            txtPublicher.Text = "";
            txtPrice.Text = "";
            txtTopic.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
            txtHelpNumber.Text = "";
            txtBookName.Select();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtBookName, "نام کتاب را وارد نمایید");
            }
            else if (txtWriter.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtWriter, "نام پدید آورنده را وارد نمایید");
            }
            else if (txtInventory.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtInventory, "موجودی را وارد نمایید");
            }
            else if (!flag)
            {
                BlAfzodanSanad bla = new BlAfzodanSanad();
                DocumentRegistration d = new DocumentRegistration();
                d.BookName = txtBookName.Text.Trim();
                d.Writer = txtWriter.Text.Trim();
                d.Inventory = txtInventory.Text.Trim();
                d.CoverName = txtCoverName.Text.Trim();
                d.PartNumber = txtPartNumber.Text.Trim();
                d.Publisher = txtPublicher.Text.Trim();
                d.Price = txtPrice.Text.Trim();
                d.Topic = txtTopic.Text;
                d.Date = txtDate.Text;
                d.Description = txtDescription.Text;
                d.HelpNumber = txtHelpNumber.Text.Trim();
                MessageBox.Show(text: bla.Create(d));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bla.Read();
                Clear();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("آیا از ویرایش سند مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DocumentRegistration d = new DocumentRegistration();
                    BlAfzodanSanad bla = new BlAfzodanSanad();
                    d.BookName = txtBookName.Text.Trim();
                    d.Writer = txtWriter.Text.Trim();
                    d.Inventory = txtInventory.Text.Trim();
                    d.CoverName = txtCoverName.Text.Trim();
                    d.PartNumber = txtPartNumber.Text.Trim();
                    d.Publisher = txtPublicher.Text.Trim();
                    d.Price = txtPrice.Text.Trim();
                    d.Topic = txtTopic.Text;
                    d.Description = txtDescription.Text;
                    d.Date = txtDate.Text;
                    d.HelpNumber = txtHelpNumber.Text.Trim();
                    MessageBox.Show(text: bla.Update(id, d));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    Clear();
                    flag = false;
                    btnRegister.Text = "افزودن سند (Ctrl + S)";
                    btnUpdate.Text = "ویرایش";
                    btnShowInformation.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                    dataGridView1.Enabled = true;
                }
                else if (result == DialogResult.No)
                {
                    flag = false;
                    btnRegister.Text = "افزودن سند (Ctrl + S)";
                    btnUpdate.Text = "ویرایش";
                    Clear();
                    btnShowInformation.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                    dataGridView1.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                flag = true;
                btnRegister.Text = "بروزرسانی سند (Ctrl + S)";
                btnUpdate.Text = "لغو";
                DocumentRegistration d = new DocumentRegistration();
                BlAfzodanSanad bla = new BlAfzodanSanad();
                d = bla.Read(id);
                txtBookName.Text = d.BookName;
                txtWriter.Text = d.Writer;
                txtInventory.Text = d.Inventory;
                txtCoverName.Text = d.CoverName;
                txtPartNumber.Text = d.PartNumber;
                txtPublicher.Text = d.Publisher;
                txtPrice.Text = d.Price;
                txtDate.Text = d.Date;
                txtTopic.Text = d.Topic;
                txtDescription.Text = d.Description;
                txtHelpNumber.Text = d.HelpNumber;
                dataGridView1.Enabled = false;
                btnShowInformation.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            }
            else
            {
                flag = false;
                btnRegister.Text = "افزودن سند (Ctrl + S)";
                btnUpdate.Text = "ویرایش";
                Clear();
                btnShowInformation.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
                dataGridView1.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnShowInformation.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("آیا از حذف سند مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                BlAfzodanSanad bla = new BlAfzodanSanad();
                if (bla.Check(id))
                {
                    MessageBox.Show("ابتدا رکورد های مربوط به این سند را در بخش امانت کتاب حذف نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bla.Delete(id);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    MessageBox.Show("سند حذف شد");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            DocumentRegistration d = new DocumentRegistration();
            BlAfzodanSanad bla = new BlAfzodanSanad();
            d = bla.Read(id);
            txtBookName.Text = d.BookName;
            txtWriter.Text = d.Writer;
            txtInventory.Text = d.Inventory;
            txtCoverName.Text = d.CoverName;
            txtPartNumber.Text = d.PartNumber;
            txtPublicher.Text = d.Publisher;
            txtPrice.Text = d.Price;
            txtDate.Text = d.Date;
            txtTopic.Text = d.Topic;
            txtDescription.Text = d.Description;
            txtHelpNumber.Text = d.HelpNumber;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnRegister.Enabled = false;
            txtBookName.Enabled = false;
            txtWriter.Enabled = false;
            txtInventory.Enabled = false;
            txtCoverName.Enabled = false;
            txtPartNumber.Enabled = false;
            txtPublicher.Enabled = false;
            txtPrice.Enabled = false;
            txtTopic.Enabled = false;
            txtDescription.Enabled = false;
            txtHelpNumber.Enabled = false;
            txtDate.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnRegister.Enabled = true;
            txtBookName.Enabled = true;
            txtWriter.Enabled = true;
            txtInventory.Enabled = true;
            txtCoverName.Enabled = true;
            txtPartNumber.Enabled = true;
            txtPublicher.Enabled = true;
            txtPrice.Enabled = true;
            txtTopic.Enabled = true;
            txtDescription.Enabled = true;
            txtHelpNumber.Enabled = true;
            txtDate.Enabled = true
                ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BlAfzodanSanad bla = new BlAfzodanSanad();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read(txtSearch.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            BlAfzodanSanad bla = new BlAfzodanSanad();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read(txtSearch.Text);

        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5_Click(sender, e);
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWriter.Select();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInventory.Select();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHelpNumber.Select();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPartNumber.Select();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPublicher.Select();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Select();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDate.Select();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Select();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
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
            else if (keyData == (Keys.Control | Keys.S))
            {

                if (txtBookName.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtBookName, "نام کتاب را وارد نمایید");
                }
                else if (txtWriter.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtWriter, "نام پدید آورنده را وارد نمایید");
                }
                else if (txtInventory.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtInventory, "موجودی را وارد نمایید");
                }
                else if (!flag)
                {
                    BlAfzodanSanad bla = new BlAfzodanSanad();
                    DocumentRegistration d = new DocumentRegistration();
                    d.BookName = txtBookName.Text.Trim();
                    d.Writer = txtWriter.Text.Trim();
                    d.Inventory = txtInventory.Text.Trim();
                    d.CoverName = txtCoverName.Text.Trim();
                    d.PartNumber = txtPartNumber.Text.Trim();
                    d.Publisher = txtPublicher.Text.Trim();
                    d.Price = txtPrice.Text.Trim();
                    d.Topic = txtTopic.Text;
                    d.Description = txtDescription.Text;
                    d.Date = txtDate.Text;
                    d.HelpNumber = txtHelpNumber.Text.Trim();
                    MessageBox.Show(text: bla.Create(d));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bla.Read();
                    Clear();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("آیا از ویرایش سند مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DocumentRegistration d = new DocumentRegistration();
                        BlAfzodanSanad bla = new BlAfzodanSanad();
                        d.BookName = txtBookName.Text.Trim();
                        d.Writer = txtWriter.Text.Trim();
                        d.Inventory = txtInventory.Text.Trim();
                        d.CoverName = txtCoverName.Text.Trim();
                        d.PartNumber = txtPartNumber.Text.Trim();
                        d.Publisher = txtPublicher.Text.Trim();
                        d.Price = txtPrice.Text.Trim();
                        d.Topic = txtTopic.Text;
                        d.Description = txtDescription.Text;
                        d.Date = txtDate.Text;
                        d.HelpNumber = txtHelpNumber.Text.Trim();
                        MessageBox.Show(text: bla.Update(id, d));
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bla.Read();
                        Clear();
                        flag = false;
                        btnRegister.Text = "افزودن سند (Ctrl + S)";
                        btnUpdate.Text = "ویرایش";
                        btnShowInformation.Enabled = true;
                        btnDelete.Enabled = true;
                        btnClear.Enabled = true;
                        dataGridView1.Enabled = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        flag = false;
                        btnRegister.Text = "افزودن سند (Ctrl + S)";
                        btnUpdate.Text = "ویرایش";
                        Clear();
                        btnShowInformation.Enabled = true;
                        btnDelete.Enabled = true;
                        btnClear.Enabled = true;
                        dataGridView1.Enabled = true;
                    }
                }
                
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

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCoverName.Select();
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BlAfzodanSanad bla = new BlAfzodanSanad();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bla.Read(txtBookName.Text);
            errorProvider1.SetError(txtBookName, "");
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTopic.Select();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtWriter, "");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtInventory, "");
        }
    }
}
