using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Exchange_Market
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach(var his in Globals.ActiveUser.history)
            {
                
                if (his.type == "buy")
                {
                    Panel panel = createPanelBuy(his);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }

        private Panel createPanelBuy(History his)
        {
            Panel panel1 = new Panel();

            Label lb_name = new Label();
            lb_name.AutoSize = true;
            lb_name.Location = new System.Drawing.Point(109, 18);
            lb_name.Size = new System.Drawing.Size(79, 29);
            lb_name.Text = his.crypto.name;

            Label lb_code_name = new Label();
            lb_code_name.AutoSize = true;
            lb_code_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_code_name.Location = new System.Drawing.Point(110, 47);
            lb_code_name.Size = new System.Drawing.Size(53, 20);
            lb_code_name.Text = his.crypto.code_name;

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Size = new System.Drawing.Size(100, 100);
            pictureBox1.TabStop = false;
            pictureBox1.Image = his.crypto.bit_image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(109, 89);
            label1.Size = new System.Drawing.Size(139, 29);
            label1.Text = "Giá lúc mua: 1.000đ";

            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(109, 133);
            label2.Size = new System.Drawing.Size(185, 29);
            label2.Text = "Giá mua hiện tại: " + his.crypto.buy_prices[29].ToString("C5", CultureInfo.CurrentCulture);

            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lb_code_name);
            panel1.Controls.Add(lb_name);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Size = new System.Drawing.Size(594, 181);

            return panel1;
        }
    }
}
