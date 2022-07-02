using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PC_Store
{
    public partial class Аuthorization : Form
    {
        SqlConnection con1;
        public Аuthorization()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = Computer Store; Integrated Security = true");
            InitializeComponent();
        }

        private void Sign_in_button_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Equals("")) || (textBox2.Text.Equals("")))
            {
                MessageBox.Show("Вы не ввели все необходимые данные!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                con1.Close();
                return;
            }
            string sproc = "exec dbo.selUser'" + textBox1.Text
              + "' , '" + textBox2.Text
              + "'";

            SqlCommand comins = new SqlCommand(sproc);
            comins.Connection = con1;

            SqlDataAdapter _da1 = new SqlDataAdapter(comins);
            DataTable _dtb1 = new DataTable();
            _da1.Fill(_dtb1);

            if (textBox1.Text == Convert.ToString(_dtb1.Rows[0][1]) && Convert.ToString(_dtb1.Rows[0][1]) == "Admin" && textBox2.Text == "2")
            {
                MessageBox.Show("Успех",
                "Админ",
                MessageBoxButtons.OK);
                this.Hide();
                Admin_menu first = new Admin_menu();
                first.Show();
            }
            else if (textBox1.Text == Convert.ToString(_dtb1.Rows[0][1]) && textBox2.Text == Convert.ToString(_dtb1.Rows[0][2]))
            {
                //Current_User.Current_User_Name = CtextBox1.Text;
                MessageBox.Show("Успех",
                "Успех",
                MessageBoxButtons.OK);
                Current_User.UserID = textBox1.Text;
                this.Hide();
                Store first = new Store();
                first.Show();

                
            }
            else
            {
                MessageBox.Show("Такого пользователя нет",
                "Ошибка",
                MessageBoxButtons.OK);
            }
            con1.Close();
        }

        private void registration_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration Reg = new Registration();
            Reg.Show();
        }
    }
}
