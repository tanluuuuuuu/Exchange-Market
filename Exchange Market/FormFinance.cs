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
    public partial class FormFinance : Form
    {
        public FormFinance()
        {
            InitializeComponent();
        }

        private void FormFinance_Load(object sender, EventArgs e)
        {
            foreach(var crt in Globals.Cryptos)
            {
                addCryptoToPanle(crt);
            }
        }
        
        private void addCryptoToPanle(Crypto crt)
        {
            Panel panel7 = new System.Windows.Forms.Panel();
            

            Label label10 = new System.Windows.Forms.Label();
            label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(63, 67);
            label10.Size = new System.Drawing.Size(62, 20);
            label10.Text = crt.convert.ToString("0.##");

            Label label11 = new System.Windows.Forms.Label();
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(64, 29);
            label11.Size = new System.Drawing.Size(54, 17);
            label11.Text = crt.code_name;

            Label label12 = new System.Windows.Forms.Label();
            label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(59, 0);
            label12.Size = new System.Drawing.Size(70, 25);
            label12.Text = crt.name;

            PictureBox pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox4.Location = new System.Drawing.Point(3, 24);
            pictureBox4.Size = new System.Drawing.Size(50, 50);
            pictureBox4.TabStop = false;
            pictureBox4.Image = crt.bit_image;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label11);
            panel7.Controls.Add(label12);
            panel7.Controls.Add(pictureBox4);
            panel7.Location = new System.Drawing.Point(3, 3);
            panel7.Size = new System.Drawing.Size(397, 100);

           
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

    }
}
