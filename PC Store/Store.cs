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
    public partial class Store : Form
    {
        SqlConnection con1;
        public Store()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = Computer Store; Integrated Security = true");
            InitializeComponent();
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
        private void CartGrid()
        {
            //string SQL_Cart_Grid = "Select "
        }
        private void Store_Load(object sender, EventArgs e)
        {
            PopulateGrid();
            label2.Text = Current_User.UserID;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "chk";
            dataGridView1.Columns.Insert(0, chk);

        }

        private void go_to_cart_Click(object sender, EventArgs e)
        {

        }

        private void add_product_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Название");
            dt.Columns.Add("Категория");
            dt.Columns.Add("Цена");
            dt.Columns.Add("Количество");
            
            foreach(DataGridViewRow drv in dataGridView1.Rows)
            {
                bool checkbox = Convert.ToBoolean(drv.Cells["chk"].Value);
                if (checkbox)
                {
                    dt.Rows.Add(drv.Cells[2].Value, drv.Cells[4].Value, drv.Cells[5].Value, drv.Cells[6].Value);
                    //dataGridView2.Rows.Add();
                    //for (int j = 0; j < dataGridView2.Rows.Count; j++)
                    //{
                    //    dataGridView2.Rows[j].Cells = dataGridView1.Rows[i].Cells["Код товара"].Value.ToString();
                    //    MessageBox.Show("Успех",
                    //"Успех",
                    //MessageBoxButtons.OK);
                    //}
                }
                dataGridView2.DataSource = dt;
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Аuthorization auth = new Аuthorization();
            auth.Show();
        }
    }
}
