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
    }
}
