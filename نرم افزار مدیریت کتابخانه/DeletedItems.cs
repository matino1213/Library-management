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
    public partial class DeletedItems : Form
    {
        public DeletedItems()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void DeletedItems_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            BlDeletedItems bld = new BlDeletedItems();
            dataGridView3.DataSource = bld.ReadDoc();
            dataGridView2.DataSource = bld.ReadMem();
            dataGridView1.DataSource = bld.ReadBookLoan();
        }
        int idLoan;
        int idDoc;
        int idMem;

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDoc = (int)dataGridView3.Rows[e.RowIndex].Cells[0].Value;
            btnDeleteDoc.Enabled = true;
            btnReturnDoc.Enabled = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idMem = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            btnDeleteMem.Enabled = true;
            btnReturnMem.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idLoan = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnDeleteLoan.Enabled = true;
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            DialogResult result;
            result = MessageBox.Show("آیا از حذف کامل کتاب مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bld.DeleteDoc(idDoc);
                MessageBox.Show("کتاب حذف شد");
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = bld.ReadDoc();
                buttonEnable();
            }
        }

        private void btnDeleteMem_Click(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            DialogResult result;
            result = MessageBox.Show("آیا از حذف کامل کاربر مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bld.DeleteMem(idMem);
                MessageBox.Show("کاربر حذف شد");
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bld.ReadMem();
                buttonEnable();
            }
        }

        private void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            DialogResult result;
            result = MessageBox.Show("آیا از حذف کامل امانت مطمئنید ؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bld.DeleteBookLoan(idLoan);
                MessageBox.Show("امانت حذف شد");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bld.ReadBookLoan();
                buttonEnable();
            }
        }

        private void btnReturnDoc_Click(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            DocumentRegistration d = new DocumentRegistration();
            d.BookName = bld.ReadDoc(idDoc).BookName;
            d.CoverName = bld.ReadDoc(idDoc).CoverName;
            d.Date = bld.ReadDoc(idDoc).Date;
            d.Description = bld.ReadDoc(idDoc).Description;
            d.HelpNumber = bld.ReadDoc(idDoc).HelpNumber;
            d.Inventory = bld.ReadDoc(idDoc).Inventory;
            d.PartNumber = bld.ReadDoc(idDoc).PartNumber;
            d.Price = bld.ReadDoc(idDoc).Price;
            d.Publisher = bld.ReadDoc(idDoc).Publisher;
            d.Topic = bld.ReadDoc(idDoc).Topic;
            d.Writer = bld.ReadDoc(idDoc).Writer;
            MessageBox.Show(text: bld.CreateDoc(d));
            bld.DeleteDoc(idDoc);
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = bld.ReadDoc();
            buttonEnable();
        }

        private void btnReturnMem_Click(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            MemberRegistration m = new MemberRegistration();
            m.ClassName = bld.ReadMem(idMem).ClassName;
            m.Classroom_id = bld.ReadMem(idMem).Classroom_id;
            m.CompletionDate = bld.ReadMem(idMem).CompletionDate;
            m.Credit = bld.ReadMem(idMem).Credit.Value;
            m.Date = bld.ReadMem(idMem).Date;
            m.Name = bld.ReadMem(idMem).Name;
            m.NationalCode = bld.ReadMem(idMem).NationalCode;
            m.OtherSpecifications = bld.ReadMem(idMem).OtherSpecifications;
            m.PhoneNumber = bld.ReadMem(idMem).PhoneNumber;
            m.Status = bld.ReadMem(idMem).Status;
            m.UserType = bld.ReadMem(idMem).UserType;
            string a = bld.CreateMem(m);
            MessageBox.Show(a);
            if (a == "عضو با موفقیت بازگردانی شد")
            {
                bld.DeleteMem(idMem);
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bld.ReadMem();
            buttonEnable();
        }
        private void buttonEnable()
        {
            btnDeleteDoc.Enabled = false;
            btnDeleteMem.Enabled = false;
            btnDeleteLoan.Enabled = false;
            btnReturnDoc.Enabled = false;
            btnReturnMem.Enabled = false;
        }

        

        private void txtSearchDoc_TextChanged(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = bld.ReadDoc(txtSearchDoc.Text);
        }

        private void txtSearchMem_TextChanged(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bld.ReadMem(txtSearchMem.Text);
        }

        private void txtSearchLoan_TextChanged(object sender, EventArgs e)
        {
            BlDeletedItems bld = new BlDeletedItems();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bld.ReadBookLoan(txtSearchLoan.Text);
        }
    }
}
