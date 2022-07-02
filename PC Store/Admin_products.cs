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
    
    public partial class Admin_products : Form
    {
        SqlConnection con1;

        bool btn4 = false;
        public Admin_products()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = Computer Store; Integrated Security = true");
            InitializeComponent();
        }
        private void textbox_clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void Disable_Buttons()
        {

            if (btn4 == true)
            {
                add.Enabled = false;
                add.BackColor = Color.Red;

                back_button.Enabled = false;
                back_button.BackColor = Color.Red;

                delete.Enabled = false;
                delete.BackColor = Color.Red;

                save.Enabled = true;
                save.BackColor = Color.Green;
            }
            else if (btn4 == false)
            {
                add.Enabled = true;
                add.BackColor = Color.GreenYellow;

                back_button.Enabled = true;
                back_button.BackColor = Color.GreenYellow;

                delete.Enabled = true;
                delete.BackColor = Color.GreenYellow;

                save.Enabled = false;
                save.BackColor = Color.Red;
            }
        }

        private void PopulateGrid()
        {
            string SQL_Grid = "SELECT * FROM Товары";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Grid, con1);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            con1.Close();
        }

        private void Admin_products_Load(object sender, EventArgs e)
        {
            PopulateGrid();

            btn4 = false;
            Disable_Buttons();
        }

        private void add_Click(object sender, EventArgs e)
        {
            con1.Open();

            if ((textBox1.Text.Equals("")) || (textBox2.Text.Equals("")) || (textBox3.Text.Equals("")) || (textBox4.Text.Equals("")) || (textBox5.Text.Equals("")) || (textBox6.Text.Equals("")))
            {
                MessageBox.Show("Вы не ввели все необходимые данные!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                con1.Close();
                return;
            }

            string insS = "INSERT Товары values ('" + textBox1.Text
                + "','" + textBox2.Text
                + "','" + textBox3.Text
                + "','" + textBox4.Text
                + "','" + textBox5.Text
                + "','" + textBox6.Text
                + "')";

            SqlCommand seans = new SqlCommand(insS);
            seans.Connection = con1;
            seans.ExecuteNonQuery();

            MessageBox.Show("товар добавлен",
            "Сообщение об успехе",
            MessageBoxButtons.OK
            );

            textbox_clear();

            PopulateGrid();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_menu a = new Admin_menu();
            a.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con1.Open();

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM Товары WHERE [Код товара] = '" + id + "'";
                SqlCommand comm = new SqlCommand(sql, con1);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("Запись Удалена");
                PopulateGrid();
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            btn4 = true;
            Disable_Buttons();
            textBox1.BackColor = Color.Red;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            con1.Open();
            btn4 = false;
            Disable_Buttons();
            textBox1.BackColor = Color.White;
            textBox1.Enabled = true;
            dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
            dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
            dataGridView1.CurrentRow.Cells[3].Value = textBox4.Text;
            dataGridView1.CurrentRow.Cells[4].Value = textBox5.Text;
            dataGridView1.CurrentRow.Cells[5].Value = textBox6.Text;

            string change = "UPDATE Товары Set Название = '"
                + textBox2.Text + "',Производитель = '" +
                textBox3.Text + "',Категория = '" +
                textBox4.Text + "',Цена = '" +
                textBox5.Text + "',Количество = '" +
                textBox6.Text + "' where [Код товара] = '" + textBox1.Text + "'";


            textbox_clear();
            SqlCommand mm = new SqlCommand(change, con1);
            mm.ExecuteNonQuery();
            PopulateGrid();
        }
    }
}
