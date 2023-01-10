using Exchange_Market.Properties;
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
    public partial class FormNews : Form
    {
        public FormNews()
        {
            InitializeComponent();
        }

        private void btn_dangBai_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("Không được để trống nội dung");
            }

            Annoucement annoucement = new Annoucement(Globals.ActiveUser.account_name, richTextBox2.Text);
            Globals.Chat.Add(annoucement);
            Globals.updateChatData();
            renderAnnouncements();
            richTextBox2.Text = "";
        }

        private void renderAnnouncements()
        {
            flowLayoutPanel1.Controls.Clear();
            for(var i = 0; i < Globals.Chat.Count(); i++)
            {
                GroupBox panel_NewsItem = new System.Windows.Forms.GroupBox();

                Label textBox2 = new System.Windows.Forms.Label();
                textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
    | System.Windows.Forms.AnchorStyles.Left)
    | System.Windows.Forms.AnchorStyles.Right)));
                textBox2.Enabled = false;
                textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox2.Location = new System.Drawing.Point(4, 38);
                Size size = TextRenderer.MeasureText(Globals.Chat[i].content, textBox2.Font);
                textBox2.Size = new System.Drawing.Size(175, size.Height + 10);
                textBox2.Text = Globals.Chat[i].content;

                // panel_NewsItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                panel_NewsItem.Controls.Add(textBox2);
                panel_NewsItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel_NewsItem.Text = Globals.Chat[i].name;
                panel_NewsItem.Location = new System.Drawing.Point(3, 3);
                panel_NewsItem.Size = new System.Drawing.Size(720, 59 + size.Height);

                flowLayoutPanel1.Controls.Add(panel_NewsItem);
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormMarket form = new FormMarket();
            this.Hide();
            form.ShowDialog();
        }

        private void FormNews_Load(object sender, EventArgs e)
        {
            renderAnnouncements();
        }
    }
}
