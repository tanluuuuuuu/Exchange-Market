using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Market
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string user = "admin";
            string pass = "admin";
            if (user.Equals(textBox1.Text) && pass.Equals(textBox2.Text))
            {
                FormNews newsForm = new FormNews();
                this.Hide();
                newsForm.ShowDialog();
                this.Close();
            }
            else
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    label4.Text = "Hãy nhập tài khoản và mật khẩu";
                }
                else
                    if (textBox1.Text == "")
                {
                    label4.Text = "Hãy nhập tài khoản ";
                }
                else
                        if (textBox2.Text == "")
                {
                    label4.Text = "Hãy nhập mật khẩu ";
                }
                else
                    label4.Text = "Tài khoản hoặc mật khẩu không chính xác";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
            }
            else
                textBox2.PasswordChar = (char)0;
        }

       
    }
}
