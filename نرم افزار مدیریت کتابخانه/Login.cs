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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            txtUserName.Select();
            BlLogin bll = new BlLogin();
            if (bll.Readlog().@bool == true)
            {
                checkBox1.Checked = true;
                txtUserName.Text = bll.Readlog().@string;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BlLogin bll = new BlLogin();
            if (bll.Login(txtUserName.Text , txtPassword.Text) == 1)
            {
                MessageBox.Show("خوش آمدید");
                this.Hide();
                if (checkBox1.Checked)
                {
                    bll.update(checkBox1.Checked, txtUserName.Text);
                }
                else if(!checkBox1.Checked)
                {
                    bll.update(checkBox1.Checked, "");
                }
                bll.update1(txtUserName.Text);
                HomePage h = new HomePage(txtUserName.Text);
                h.Show();
            }
            else
            {
                label3.Text = "نام کاربری یا رمز عبور اشتباه است";
                txtPassword.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }
        }

        private void lblF_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaramoshiRamz f = new FaramoshiRamz();
            f.Show();
        }
    }
}
