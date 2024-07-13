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
    public partial class ShowInformation : Form
    {
        public ShowInformation()
        {
            InitializeComponent();
        }
        public ShowInformation(int id)
        {
            InitializeComponent();
            x = id;
        }
        int x;
       
        private void ShowInformation_Load(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            DocumentRegistration d = bla.Read1(x);
            textBox1.Text = d.BookName;
            textBox2.Text = d.Writer;
            textBox3.Text = d.Inventory;
            textBox4.Text = d.HelpNumber;
            textBox5.Text = d.CoverName;
            textBox6.Text = d.PartNumber;
            textBox7.Text = d.Publisher;
            textBox8.Text = d.Price;
            textBox11.Text = d.Date;
            textBox9.Text = d.Topic;
            textBox10.Text = d.Description;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
