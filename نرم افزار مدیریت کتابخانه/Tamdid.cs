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
    public partial class Tamdid : Form
    {
        public Tamdid()
        {
            InitializeComponent();
        }
        public Tamdid(int id)
        {
            InitializeComponent();
            x = id;
        }

        private void Tamdid_Load(object sender, EventArgs e)
        {
            BlAmanatKetab bla = new BlAmanatKetab();
            txtName.Text = bla.Read(x).Name;
            txtTamdid.Select();
        }
        int x;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtTamdid.Text) > 0)
            {
                BlAmanatKetab bla = new BlAmanatKetab();
                MemberRegistration m = new MemberRegistration();
                m.Status = "فعال";
                m.Credit = int.Parse(txtTamdid.Text);
                MessageBox.Show(text: bla.Update2(x, m));
                this.Close();
                AmanatKetab.ActiveForm.Close();
                AmanatKetab a = new AmanatKetab();
                a.Show();
            }
            else
            {
                MessageBox.Show("مدت اعتبار را به درستی وارد نمایید");
                txtTamdid.Text = "";
                txtTamdid.Select();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
