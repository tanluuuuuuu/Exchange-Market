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
        List<Annoucement> annoucements = new List<Annoucement>();

        public FormNews()
        {
            InitializeComponent();
        }

        private void btn_dangBai_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Không được để trống tên hiển thị và nội dung bài");
            }

            Annoucement annoucement = new Annoucement(textBox1.Text, richTextBox1.Text);
            annoucements.Add(annoucement);
        }

        private void renderAnnouncements()
        {

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
    }
}
