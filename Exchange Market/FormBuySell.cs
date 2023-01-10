using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Globalization;

namespace Exchange_Market
{
    public partial class FormBuySell : Form
    {
        
        Crypto currentSelect = null;
        public FormBuySell()
        {
            InitializeComponent();
        }

        private void FormBuySell_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var crt in Globals.Cryptos)
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
            panel2.Size = new System.Drawing.Size(255, 100);
            panel2.Click += (sender, e) => onPanelClick(sender, e, crt);

            return panel2;
        }

        private void onPanelClick(object sender, EventArgs e, Crypto crt)
        {
            currentSelect = crt;
            chart1.Series.Clear();

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

            chart1.Series.Add(series_sell);
            chart1.Series.Add(series_buy);
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(Math.Max(max_sell, max_buy)) + 100;
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

        private void Buy_Click(object sender, EventArgs e)
        {
            if (currentSelect == null)
            {
                MessageBox.Show("Chọn một đồng để mua");
                return;
            }

            if (num_buy.Value <= 0)
            {
                MessageBox.Show("Nhập đúng số lượng để mua");
                return;
            }

            if ((decimal.ToDouble(num_buy.Value) * currentSelect.buy_prices[29]) > Globals.ActiveUser.remain_money)
            {
                MessageBox.Show("Không đủ số dư, vui lòng nạp thêm");
                return;
            }

            int index = Globals.ActiveUser.owned_crypto.FindIndex(a => a.crypto.code_name == currentSelect.code_name);
            if (index == -1)
            {
                OwnCrypto t = new OwnCrypto(currentSelect, decimal.ToDouble(num_buy.Value));
                Globals.ActiveUser.owned_crypto.Add(t);
            }
            else
            {
                Globals.ActiveUser.owned_crypto[index].quantity += decimal.ToDouble(num_buy.Value);
            }
            Globals.ActiveUser.remain_money -= (decimal.ToDouble(num_buy.Value) * currentSelect.buy_prices[29]);
            History his = new History(currentSelect, decimal.ToDouble(num_buy.Value), "buy");
            Globals.ActiveUser.history.Add(his);
            Globals.updateUserData();
            MessageBox.Show("Mua thành công, số dư mới: " + Globals.ActiveUser.remain_money.ToString("C5", CultureInfo.CurrentCulture));
        }

        private void num_buy_ValueChanged(object sender, EventArgs e)
        {
            if(currentSelect != null)
                label11.Text = "Thành tiền: " + (decimal.ToDouble(num_buy.Value) * currentSelect.buy_prices[29]).ToString("C5", CultureInfo.CurrentCulture);
        }

        private void sell_Click(object sender, EventArgs e)
        {
            if (currentSelect == null)
            {
                MessageBox.Show("Chọn một đồng để bán");
                return;
            }

            if (num_sell.Value <= 0)
            {
                MessageBox.Show("Nhập đúng số lượng để bán");
                return;
            }

            int index = Globals.ActiveUser.owned_crypto.FindIndex(a => a.crypto.code_name == currentSelect.code_name);
            if (index == -1)
            {
                MessageBox.Show("Bạn cần sỡ hữu coin này mới có thể bán");
                return;
            }
            else
            {
                if (Globals.ActiveUser.owned_crypto[index].quantity < decimal.ToDouble(num_sell.Value))
                {
                    MessageBox.Show("Số coin cần bán nhiều hơn số coin sở hữu");
                    return;
                }
                else
                {
                    Globals.ActiveUser.owned_crypto[index].quantity -= decimal.ToDouble(num_sell.Value);
                    Globals.ActiveUser.remain_money += (decimal.ToDouble(num_sell.Value) * currentSelect.buy_prices[29]);
                    History his = new History(currentSelect, decimal.ToDouble(num_sell.Value), "sell");
                    Globals.ActiveUser.history.Add(his);
                    Globals.updateUserData();
                    MessageBox.Show("Bán thành công, số dư mới: " + Globals.ActiveUser.remain_money.ToString("C5", CultureInfo.CurrentCulture));
                }
            }
        }

        private void num_sell_ValueChanged(object sender, EventArgs e)
        {
            if (currentSelect != null)
                label12.Text = "Thành tiền: " + (decimal.ToDouble(num_sell.Value) * currentSelect.sell_prices[29]).ToString("C5", CultureInfo.CurrentCulture);
        }
    }
}
