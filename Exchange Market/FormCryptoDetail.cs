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
        }
    }
}
