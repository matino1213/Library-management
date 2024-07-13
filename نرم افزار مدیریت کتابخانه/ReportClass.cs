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
    public partial class ReportClass : Form
    {
        public ReportClass()
        {
            InitializeComponent();
        }
        DateTime date1;
        DateTime date2;
        bool flagg = false;
        public ReportClass(DateTime d1, DateTime d2)
        {
            date1 = d1;
            date2 = d2;
            flagg = true;
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

        private void ReportClass_Load(object sender, EventArgs e)
        {
            if (flagg)
            {
                dataGridView1.AutoGenerateColumns = false;
                BlReportMem blr = new BlReportMem();
                blr.UpdateByDate(date1, date2);
                BlSabtClass bls = new BlSabtClass();
                bls.Check();
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(date2.ToShortDateString(), date1.ToShortDateString());
            }
            else
            {
                BlReportMem blr = new BlReportMem();
                BlSabtClass bls = new BlSabtClass();
                blr.UpdateAll();
                bls.Check();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateTime.Now.ToShortDateString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlReportMem blr = new BlReportMem();
            BlSabtClass bls = new BlSabtClass();
            if (cmbChooseDate.Text == "نمایش کل")
            {
                blr.UpdateAll();
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateTime.Now.ToString();
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "یک ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-1);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "دو ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-2);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "سه ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-3);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "شش ماه گذشته")
            {
                DateTime d1 = DateTime.Now.AddMonths(-6);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else if (cmbChooseDate.Text == "یک سال گذشته")
            {
                DateTime d1 = DateTime.Now.AddYears(-1);
                DateTime d2 = DateTime.Now;
                blr.UpdateByDate(d1, d2);
                bls.Check();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blr.Class();
                lbl.Text = blr.BookLoan().ToString();
                date = DateToString(d2.ToShortDateString(), d1.ToShortDateString());
                MessageBox.Show("جدول بروزرسانی شد");
            }
            else
            {
                this.Close();
                AddDate a = new AddDate(3);
                a.Show();
            }
        }

        private void ReportClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            BlReportMem blr = new BlReportMem();
            BlSabtClass bls = new BlSabtClass();
            blr.UpdateAll();
            bls.Check();
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
            PdfPCell pdfc = new PdfPCell(new Phrase("گزارش کلاسی در تاریخ " + date, tahoma));
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
