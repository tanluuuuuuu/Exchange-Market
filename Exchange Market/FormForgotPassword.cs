using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Exchange_Market
{
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
        }

        private void btn_submitInfo_Click(object sender, EventArgs e)
        {
            if (tb_email.Text == "" || tb_username.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                String from, to, pass, content;
                from = "luutmaocr@gmail.com";
                to = tb_email.Text;
                pass = "Luu432002@@";
                content = "Code to recovery account " + tb_username.Text + " is: 19836";

                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from);
                mail.Subject = "Password Recovery";
                mail.Body = content;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(from, pass);

                try
                {
                    smtp.Send(mail);
                    MessageBox.Show("Vui lòng kiểm tra hộp thư thoại");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
