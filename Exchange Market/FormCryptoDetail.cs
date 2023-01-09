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
    public partial class FormCryptoDetail : Form
    {
        public FormCryptoDetail()
        {
            InitializeComponent();
        }

        public FormCryptoDetail(Crypto crt)
        {
            InitializeComponent();
            MessageBox.Show(crt.name);
            linkLabel1.Text = crt.name;
            label1.Text = crt.code_name;
            label2.Text = crt.convert.ToString("0.##");
            pictureBox1.Image = crt.bit_image;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
