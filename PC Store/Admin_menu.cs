using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Store
{
    public partial class Admin_menu : Form
    {
        public Admin_menu()
        {
            InitializeComponent();
        }

        private void users_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_users Am = new Admin_users();
            Am.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_products Ap = new Admin_products();
            Ap.Show();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Аuthorization auth = new Аuthorization();
            auth.Show();
        }
    }
}
