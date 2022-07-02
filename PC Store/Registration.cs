using System;
using System.Collections.Generic;
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
    
    public partial class Registration : Form
    {
        SqlConnection con1;
        public Registration()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = Computer Store; Integrated Security = true");
            InitializeComponent();
        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            con1.Open();
   
            string iproc = "exec dbo.insP '" + textBox1.Text
                + "','" + textBox2.Text
                + "'";

            SqlCommand comins = new SqlCommand(iproc);
            comins.Connection = con1;
            comins.ExecuteNonQuery();

            MessageBox.Show("Успех!",
            "Сообщение об успехе",
            MessageBoxButtons.OK
            );

            con1.Close();
        }

        private void auth_return_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Аuthorization auth = new Аuthorization();
            auth.Show();
        }
    }
}
