using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;

namespace Exchange_Market
{
    public partial class FormMarket : Form
    {
        Crypto currentSelect;

        public FormMarket()
        {
            InitializeComponent();
        }

        private void FormMarket_Load(object sender, EventArgs e)
        {
            if (currentSelect != null)
            {
                if (currentSelect.isFav)
                    button7.Text = "Bỏ thích";
                else
                    button7.Text = "Yêu thích";
            }

            flPanel_All.Controls.Clear();
            flPanel_Metaverse.Controls.Clear();
            flPanel_Gaming.Controls.Clear();
            flPanel_DeFi.Controls.Clear();
            flPanel_Innovation.Controls.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();

            foreach (var crt in Globals.Cryptos)
            {
                Panel panel = addCryptosToFlowPanel(crt);

                flPanel_All.Controls.Add(panel);

                panel = addCryptosToFlowPanel(crt);
                if (crt.type == "Metaverse")
                    flPanel_Metaverse.Controls.Add(panel);
                else if (crt.type == "Gaming")
                    flPanel_Gaming.Controls.Add(panel);
                else if (crt.type == "DeFi")
                    flPanel_DeFi.Controls.Add(panel);
                else if (crt.type == "Innovation")
                    flPanel_Innovation.Controls.Add(panel);
            }

            foreach (var crt in Globals.ActiveUser.fav_crypto)
            {
                Panel panel = addCryptosToFlowPanel(crt);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private Panel addCryptosToFlowPanel(Crypto crt)
        {
            Panel panel2 = new System.Windows.Forms.Panel();

            Label label1 = new System.Windows.Forms.Label();
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(59, 0);
            label1.Size = new System.Drawing.Size(70, 25);
            label1.Text = crt.name;

            Label label2 = new System.Windows.Forms.Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(64, 29);
            label2.Size = new System.Drawing.Size(46, 17);
            label2.Text = crt.code_name;

            Label label3 = new System.Windows.Forms.Label();
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(63, 69);
            label3.Size = new System.Drawing.Size(53, 20);
            label3.Text = crt.convert.ToString("0.##");

            PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox1.Location = new System.Drawing.Point(3, 24);
            pictureBox1.Size = new System.Drawing.Size(50, 50);
            pictureBox1.Image = crt.bit_image;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Size = new System.Drawing.Size(285, 100);
            panel2.Click += (sender, e) => onPanelClick(sender, e, crt);

            return panel2;
        }

        private GroupBox createGroupBox(Annoucement cm)
        {
            TextBox textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Size = new System.Drawing.Size(400, 72);
            textBox1.Text = cm.content;

            GroupBox groupBox2 = new GroupBox();
            groupBox2.Controls.Add(textBox1);
            groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Size = new System.Drawing.Size(400, 100);
            groupBox2.Text = cm.name;

            return groupBox2;
        }

        private void onPanelClick(object sender, EventArgs e, Crypto crt)
        {

            currentSelect = crt;
            flowLayoutPanel3.Controls.Clear();

            if (currentSelect.isFav)
                button7.Text = "Bỏ thích";
            else
                button7.Text = "Yêu thích";

            chart3.Series.Clear();
            chart_All.Series.Clear();

            Series series_sell = new Series("Sell Price");
            series_sell.ChartType = SeriesChartType.Line;
            series_sell.BorderWidth = 3;

            Series series_buy = new Series("Buy Price");
            series_buy.ChartType = SeriesChartType.Line;
            series_buy.BorderWidth = 3;

            double max_sell = crt.sell_prices.Max(t => t);
            double max_buy = crt.buy_prices.Max(t => t);

            for (int i = 1; i <= 30; i++)
            {
                series_sell.Points.AddXY(i, crt.sell_prices[i - 1]);
                series_buy.Points.AddXY(i, crt.buy_prices[i - 1]);
            }

            chart3.Series.Add(series_sell);
            chart3.Series.Add(series_buy);
            chart3.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(Math.Max(max_sell, max_buy)) + 100;

            chart_All.Series.Add(series_sell);
            chart_All.Series.Add(series_buy);
            chart_All.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(Math.Max(max_sell, max_buy)) + 100;

            foreach (var comm in currentSelect.comments)
            {
                GroupBox grb = createGroupBox(comm);
                flowLayoutPanel3.Controls.Add(grb);
            }
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
            Globals.deactivateUser();
            FormLogin form = new FormLogin();
            this.Hide();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentSelect.isFav = !currentSelect.isFav;
            int index = Globals.ActiveUser.fav_crypto.FindIndex(q => q.code_name == currentSelect.code_name);
            if (index == -1)
            {
                Globals.ActiveUser.fav_crypto.Add(currentSelect);
            }
            else
                Globals.ActiveUser.fav_crypto.Remove(Globals.ActiveUser.fav_crypto[index]);

            Globals.updateUserData();
            FormMarket_Load(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCryptoDetail form = new FormCryptoDetail(currentSelect);
            form.ShowDialog();
        }

        private void btn_comment_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                return;
            }
            if (currentSelect == null)
            {
                return;
            }

            Annoucement comment = new Annoucement(Globals.ActiveUser.account_name,
                richTextBox1.Text,
                DateTime.Now,
                currentSelect);
            currentSelect.comments.Add(comment);
            Globals.updateCryptoComment();
            richTextBox1.Text = "";
            
            flowLayoutPanel3.Controls.Clear();
            foreach (var comm in currentSelect.comments)
            {
                GroupBox grb = createGroupBox(comm);
                flowLayoutPanel3.Controls.Add(grb);
            }
        }
    }
}
