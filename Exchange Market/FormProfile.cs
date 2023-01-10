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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        public FormProfile(User user)
        {
            InitializeComponent();
            label1.Text = "Tên hiển thị: " + user.account_name;
            label2.Text = "Tài sản ròng: " + user.balance.ToString("C5", CultureInfo.CurrentCulture);            
            
        }
        private void FormProfile_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var crt in Globals.ActiveUser.owned_crypto)
            {
                addCryptoToPanle(crt);
            }
        }

        private void addCryptoToPanle(OwnCrypto crt)
        {
            Panel panel1 = new System.Windows.Forms.Panel();

            Label label3 = new System.Windows.Forms.Label();
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(85, 9);
            label3.Size = new System.Drawing.Size(64, 25);
            label3.Text = crt.crypto.name;

            Label label4 = new System.Windows.Forms.Label();
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(74, 43);
            label4.Size = new System.Drawing.Size(44, 16);
            label4.Text = crt.crypto.code_name;

            Label label5 = new System.Windows.Forms.Label();
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(87, 71);
            label5.Size = new System.Drawing.Size(53, 20);
            label5.Text = crt.crypto.convert.ToString("0.##");

            PictureBox pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox2.Location = new System.Drawing.Point(18, 27);
            pictureBox2.Size = new System.Drawing.Size(50, 50);
            pictureBox2.TabStop = false;
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = crt.crypto.bit_image;

            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Size = new System.Drawing.Size(300, 100);

            flowLayoutPanel1.Controls.Add(panel1);
        }

        
    }
}
