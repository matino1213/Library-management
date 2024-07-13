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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace نرم_افزار_مدیریت_کتابخانه
{
    public partial class ReportDoc : Form
    {
        public ReportDoc()
        {
            InitializeComponent();
        }
        DateTime date1;
        DateTime date2;
        public ReportDoc(DateTime d1, DateTime d2)
        {
            date1 = d1;
            date2 = d2;
            flag = true;
            InitializeComponent();
        }
        bool flag = false;
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

        private void ReportDoc_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                dataGridView1.AutoGenerateColumns = false;
                BlReportDoc blr = new BlReportDoc();
                blr.UpdateByDate(date1, date2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(date2.ToShortDateString(), date1.ToShortDateString());
            }
            else
            {
                dataGridView1.AutoGenerateColumns = false;
                BlReportDoc blr = new BlReportDoc();
                blr.UpdateAll();
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateTime.Now.ToShortDateString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BlReportDoc blr = new BlReportDoc();
            dataGridView1.DataSource = blr.Read(txtSearch.Text);
            cmbChooseDate.Text = "";
        }
        int id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            btnShowInfo.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowInformation s = new ShowInformation(id);
            s.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlReportDoc blr = new BlReportDoc();
            if (cmbChooseDate.Text == "نمایش کل")
            {
                blr.UpdateAll();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateTime.Now.ToString();
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "یک ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-1);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "دو ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-2);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "سه ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-3);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "شش ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-6);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "یک سال گذشته")
            {
                DateTime d1 = DateTime.Now.AddYears(-1);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Read();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else
            {
                this.Close();
                AddDate a = new AddDate(1);
                a.Show();
            }
        }

        private void ReportDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            BlReportDoc blr = new BlReportDoc();
            blr.UpdateAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blr.Read();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "pdf Name (*.pdf)|*.pdf";
            saveFileDialog1.FileName = String.Empty;
            saveFileDialog1.DefaultExt = ".pdf";

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                CreatePDF(saveFileDialog1.FileName);
            }
        }
        string date;
        private void CreatePDF(string Address)
        {
            Document doc = new Document(PageSize.A4);
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            PdfPTable t = new PdfPTable(numColumns: 1);

            PdfWriter pwriter = PdfWriter.GetInstance(doc, new FileStream(Address, FileMode.Create));
            doc.Open();

            FontFactory.Register("c:\\windows\\fonts\\tahoma.ttf");
            iTextSharp.text.Font tahoma = FontFactory.GetFont("tahoma", BaseFont.IDENTITY_H, 10, 1, BaseColor.BLACK);
            PdfPCell pdfc = new PdfPCell(new Phrase("گزارش کتاب های امانت داده شده در تاریخ " + date, tahoma));
            t.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            pdfc.HorizontalAlignment = Element.ALIGN_CENTER;
            t.AddCell(pdfc);

            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataGridView1.Columns[i].HeaderText, tahoma));
                table.AddCell(cell);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string item = dataGridView1[j, i].Value != null ? dataGridView1[j, i].Value.ToString() : "";
                    PdfPCell cell = new PdfPCell(new Phrase(item, tahoma));
                    if (i % 2 == 0)
                    {
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    }
                    table.AddCell(cell);
                }
            }
            doc.Add(t);
            doc.Add(table);
            doc.Close();

            Process.Start(Address);
        }
        private string DateToString(string d1, string d2)
        {
            return d2 + " تا " + d1;
        }
    }
}

