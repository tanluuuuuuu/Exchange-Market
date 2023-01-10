using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exchange_Market
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btn_submitRegister_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
            }
            else if (tb_password.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if (tb_passwordAgain.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu");
            }
            else if (tb_accName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên hiển thị");
            }
            else if (tb_password.Text != tb_passwordAgain.Text)
            {
                MessageBox.Show("Mật khẩu không khớp");
            }
            else
            {
                using (StreamWriter sw = File.AppendText(@".\user_data.txt"))
                {
                    sw.WriteLine(tb_accName.Text + "\t" + tb_username.Text + "\t" + tb_password.Text + "\t0\t0");
                    sw.WriteLine("None");
                    sw.WriteLine("None");
                    sw.WriteLine("None");
                }
                MessageBox.Show("Đăng ký thành công");

                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                tb_password.PasswordChar = '*';
                tb_passwordAgain.PasswordChar= '*';
            }
            else

            {
                tb_password.PasswordChar = (char)0;
                tb_passwordAgain.PasswordChar = (char)0;
            }                    
                
                
        }
    }
}
