using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Market
{
    public partial class FormAddMoney : Form
    {
        public FormAddMoney()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            string selectedType = (string)comboBox1.SelectedItem;
            panel1.Controls.Clear();
            if (selectedType == "Tài khoản ngân hàng")
            {
                Label label4 = new Label();
                label4.AutoSize = true;
                label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label4.Location = new System.Drawing.Point(2, 24);
                label4.Size = new System.Drawing.Size(205, 29);
                label4.Text = "Nhập số tài khoản";

                TextBox textBox1 = new TextBox();
                textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox1.Location = new System.Drawing.Point(222, 21);
                textBox1.Size = new System.Drawing.Size(335, 34);

                ComboBox comboBox2 = new ComboBox();
                comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                comboBox2.FormattingEnabled = true;
                comboBox2.Items.AddRange(new object[] {
            "Vietcombank",
            "Sacombank",
            "Agribank"});
                comboBox2.Location = new System.Drawing.Point(222, 66);
                comboBox2.Size = new System.Drawing.Size(335, 37);

                Label label5 = new Label();
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label5.Location = new System.Drawing.Point(-2, 66);
                label5.Size = new System.Drawing.Size(188, 29);
                label5.Text = "Chọn ngân hàng";
                
                TextBox textBox2 = new TextBox();
                textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox2.Location = new System.Drawing.Point(222, 110);
                textBox2.Size = new System.Drawing.Size(335, 34);

                Label label6 = new Label();
                label6.AutoSize = true;
                label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label6.Location = new System.Drawing.Point(-2, 110);
                label6.Size = new System.Drawing.Size(212, 29);
                label6.Text = "Nhập tên tài khoản";

                panel1.Controls.Add(label4);
                panel1.Controls.Add(textBox1);
                panel1.Controls.Add(comboBox2);
                panel1.Controls.Add(label5);
                panel1.Controls.Add(label6);
                panel1.Controls.Add(textBox2);
            }
            else
            {
                Label label5 = new Label();
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label5.Location = new System.Drawing.Point(-2, 66);
                label5.Size = new System.Drawing.Size(188, 29);
                label5.Text = "Nhập số điện thoại";

                TextBox textBox2 = new TextBox();
                textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox2.Location = new System.Drawing.Point(222, 66);
                textBox2.Size = new System.Drawing.Size(335, 34);

                panel1.Controls.Add(label5);
                panel1.Controls.Add(textBox2);
            }
        }

        private void btn_submitRegister_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value <= 0 && comboBox1.Text != "Ví điện tử MOMO" && comboBox1.Text != "Tài khoản ngân hàng")
            {
                MessageBox.Show("Vui lòng nhập lại số tiền và chọn phương thức thanh toán.");
            }
            else if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền lớn hơn 0.");
            }
            else if(comboBox1.Text != "Ví điện tử MOMO" && comboBox1.Text != "Tài khoản ngân hàng")
            {
                        MessageBox.Show("Hãy chọn phương thức thanh toán.");
            }
              
            if(comboBox1.Text == "Ví điện tử MOMO")
                foreach (var item in panel1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)item;
                     if(tb.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập số điện thoại.");
                        }    

                }
                
            }
             else if (comboBox1.Text == "Tài khoản ngân hàng")
                foreach (var item in panel1.Controls)
                {
                    if (item.GetType() == typeof(TextBox))
                    {
                        TextBox tb1 = (TextBox)item;
                        if (tb1.Text == "")
                        {
                            MessageBox.Show("Hãy nhập số tài khoản hặc tên tài khoản.");
                            
                        }
                        
                       
                    }
                    else if (item.GetType() == typeof(ComboBox))
                    {
                        ComboBox cb = (ComboBox)item;
                        if (cb.Text == "")
                        {
                            MessageBox.Show("Vui lòng chọn ngân hàng.");
                        }    

                    }
                    
                }


        }
    }
}
