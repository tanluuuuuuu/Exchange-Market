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

namespace Exchange_Market
{
    public partial class FormMarket : Form
    {
        List<Crypto> cryptos = new List<Crypto>();

        public FormMarket()
        {
            InitializeComponent();
        }

        private void FormMarket_Load(object sender, EventArgs e)
        {
            cryptos.Add(new Crypto("BNB", "BNB"));
            cryptos.Add(new Crypto("ETH", "ETH"));

            foreach (var crt in cryptos)
            {
                addCryptosToFlowPanel(crt);
            }

            Series series1 = new Series("Series 2");
            series1.ChartType = SeriesChartType.Line;

            // Add points to it.
            series1.Points.AddXY(0, 2);
            series1.Points.AddXY(1, 2);
            series1.Points.AddXY(2, 12);
            series1.Points.AddXY(3, 14);
            series1.Points.AddXY(4, 17);
            series1.Points.AddXY(5, 20);

            chart1.Series.Add(series1);
        }

        private void addCryptosToFlowPanel(Crypto crt)
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

            panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Size = new System.Drawing.Size(285, 100);
            
            flowLayoutPanel1.Controls.Add(panel2);
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
