﻿using System;
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
    public partial class FormExchange : Form
    {
        List<Crypto> cryptos = new List<Crypto>();
   
        public FormExchange()
        {
            InitializeComponent();
        }

        private void FormExchange_Load(object sender, EventArgs e)
        {
            cryptos.Add(new Crypto("BNB", "BNB", 1.5));
            cryptos.Add(new Crypto("ETH", "ETH", 1.25));
            cryptos.Add(new Crypto("SOL", "SOL", 1.3));
            cryptos.Add(new Crypto("BUSD", "BUSD", 1.4));
            cryptos.Add(new Crypto("ADA", "ADA", 1.6));
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


    }
}
