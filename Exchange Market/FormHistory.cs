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
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }
        private void FormHistory_Load(object sender, EventArgs e)
        {
            foreach (var history in Globals.ActiveUser.history)
            {
                Panel panel = addHistoryCrypto(history.crypto);
                flowLayoutPanel1.Controls.Add(panel);
                panel = addHistoryCrypto(history.crypto);
                if (history.type == "buy")
                    flowLayoutPanel1.Controls.Add(panel1);
                else 
                    flowLayoutPanel2.Controls.Add(panel1);
            }
        }
        private Panel addHistoryCrypto(Crypto crt)
        {
            Panel panel1 = new System.Windows.Forms.Panel();

            Label Label1 = new System.Windows.Forms.Label();
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(77, 4);
            label1.Size = new System.Drawing.Size(64, 25);
            label1.Text = crt.code_name;

            Label Label2 = new System.Windows.Forms.Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(79, 38);
            label2.Size = new System.Drawing.Size(44, 16);
            label2.Text = crt.convert.ToString("0.##");

            Label Label3 = new System.Windows.Forms.Label();
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(77, 66);
            label3.Size = new System.Drawing.Size(53, 20);
            label3.Text = crt.name;

            PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox1.Location = new System.Drawing.Point(6, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(50, 50);
            pictureBox1.TabStop = false;
            pictureBox1.Image = crt.bit_image;

            Label Label7 = new System.Windows.Forms.Label();
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(209, 38);
            label7.Size = new System.Drawing.Size(53, 20);
            label7.Text = "Số lượng";

            Label Label8 = new System.Windows.Forms.Label();
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(209, 66);
            label8.Size = new System.Drawing.Size(53, 20);
            label8.Text = "Giá cả";

            panel1.Controls.Add(this.label8);
            panel1.Controls.Add(this.label7);
            panel1.Controls.Add(this.label3);
            panel1.Controls.Add(this.label2);
            panel1.Controls.Add(this.label1);
            panel1.Controls.Add(this.pictureBox1);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Size = new System.Drawing.Size(400, 100);
      


            return panel1;

        }

        
    }
}
