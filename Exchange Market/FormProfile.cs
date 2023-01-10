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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        public FormProfile(User user)
        {
            InitializeComponent();
            label1.Text = "Tên hiển thị: " + user.account_name;
            label2.Text = "Tài sản ròng: " + user.balance.ToString("C5", CultureInfo.CurrentCulture);            
            
        }

        
    }
}
