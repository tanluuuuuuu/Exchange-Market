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
    public partial class FormExchange : Form
    {
        List<Crypto> cryptos = new List<Crypto>();
        Crypto crt1 = null;
        Crypto crt2 = null;
        public FormExchange()
        {
            InitializeComponent();
        }

        private void FormExchange_Load(object sender, EventArgs e)
        {
            foreach (var crypto in Globals.Cryptos)
            {
                comboBox1.Items.Add(crypto.code_name);
                comboBox2.Items.Add(crypto.code_name);
                
            }
        }

        private void doSomething()
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "" || comboBox2.Text == "") && textBox1.Text == "")
            {
                MessageBox.Show("Hãy chọn đồng coin và nhập số coin.");
            }
            else if (comboBox1.Text=="" || comboBox2.Text=="")
            {
                MessageBox.Show("Hãy chọn coin để đổi.");
            }
            else if(textBox1.Text== "")
            {
                MessageBox.Show("Vui lòng nhập số coin.");
            }
                
                 
            double x;
            Console.WriteLine(textBox1.Text); 
            Console.WriteLine(textBox2.Text);
            if (comboBox1.Text != comboBox2.Text)
            {
                x= (double)(double.Parse(textBox1.Text) * (crt1.buy_prices[29] / crt2.buy_prices[29]));
                textBox2.Text = x.ToString();
                textBox3.Text =  ((double)(double.Parse(textBox1.Text) * crt1.buy_prices[29])).ToString("C5", CultureInfo.CurrentCulture);
                
            }
            else
                
                textBox2.Text = textBox1.Text;
                textBox3.Text = ((double)(double.Parse(textBox1.Text) * crt1.buy_prices[29])).ToString("C5", CultureInfo.CurrentCulture);

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var crypto in Globals.Cryptos)
            {
                if(crypto.code_name == (string)comboBox1.SelectedItem)
                {
                    crt1= crypto;
                    break;
                }
                
            }    
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var crypto in Globals.Cryptos)
            {
                if (crypto.code_name == (string)comboBox2.SelectedItem)
                {
                    crt2 = crypto;
                    break;
                }

            }
        }
        


    }
}
