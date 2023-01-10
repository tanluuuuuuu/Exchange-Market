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
    public partial class FormGetMoney : Form
    {
        public FormGetMoney()
        {
            InitializeComponent();
        }

        private void btn_submitRegister_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền cần rút");
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ví tiền");
                return;
            }

            if (decimal.ToDouble(numericUpDown1.Value) > Globals.ActiveUser.remain_money)
            {
                MessageBox.Show("Không đủ tiền rút");
                return;
            }

            Globals.ActiveUser.remain_money -= decimal.ToDouble(numericUpDown1.Value);
            Globals.ActiveUser.history_getMoney.Add(decimal.ToDouble(numericUpDown1.Value));
            Globals.updateUserData();
            MessageBox.Show("Rút tiền thành công");
            this.Close();
        }
    }
}
