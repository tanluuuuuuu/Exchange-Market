using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Market
{
    public partial class FormFinance : Form
    {
        public FormFinance()
        {
            InitializeComponent();
        }

        private void FormFinance_Load(object sender, EventArgs e)
        {
            lb_accountName.Text = "Tên hiển thị: " + Globals.ActiveUser.account_name;
            lb_remain.Text = "Số dư: " + Globals.ActiveUser.remain_money.ToString("C5", CultureInfo.CurrentCulture);
            lb_allMoney.Text = "Tài sản ròng: " + Globals.ActiveUser.balance.ToString("C5", CultureInfo.CurrentCulture);

            flowLayoutPanel1.Controls.Clear();
            foreach(var crt in Globals.ActiveUser.owned_crypto)
            {
                addCryptoToPanle(crt);
            }
        }
        
        private void addCryptoToPanle(OwnCrypto crt)
        {
            Panel panel7 = new System.Windows.Forms.Panel();
            

            Label label10 = new System.Windows.Forms.Label();
            label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(63, 67);
            label10.Size = new System.Drawing.Size(62, 20);
            label10.Text = crt.crypto.convert.ToString("0.##");

            Label label2 = new Label();
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(124, 67);
            label2.Size = new System.Drawing.Size(53, 20);
            label2.Text = "Giá trị: " + (crt.crypto.buy_prices[29] * crt.quantity).ToString("C5", CultureInfo.CurrentCulture);

            Label label11 = new System.Windows.Forms.Label();
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(64, 29);
            label11.Size = new System.Drawing.Size(54, 17);
            label11.Text = crt.crypto.code_name;

            Label label1 = new Label();
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(124, 26);
            label1.Size = new System.Drawing.Size(53, 20);
            label1.Text = "Số lượng: " + crt.quantity.ToString("C5", CultureInfo.CurrentCulture);

            Label label12 = new System.Windows.Forms.Label();
            label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(59, 0);
            label12.Size = new System.Drawing.Size(70, 25);
            label12.Text = crt.crypto.name;

            PictureBox pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox4.Location = new System.Drawing.Point(3, 24);
            pictureBox4.Size = new System.Drawing.Size(50, 50);
            pictureBox4.TabStop = false;
            pictureBox4.Image = crt.crypto.bit_image;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label11);
            panel7.Controls.Add(label12);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(pictureBox4);
            panel7.Location = new System.Drawing.Point(3, 3);
            panel7.Size = new System.Drawing.Size(300, 100);

            flowLayoutPanel1.Controls.Add(panel7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNews newsForm = new FormNews();
            this.Hide();
            newsForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMarket form = new FormMarket();
            this.Hide();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormExchange form = new FormExchange();
            this.Hide();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBuySell form = new FormBuySell();
            this.Hide();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormFinance form = new FormFinance();
            this.Hide();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            this.Hide();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormAddMoney form = new FormAddMoney();
            form.ShowDialog();
            FormFinance_Load(sender, e);
        }
    }
}
