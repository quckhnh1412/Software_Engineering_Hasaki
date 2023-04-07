using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Admin_login : Form
    {
        public Admin_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            string query = "SELECT HOTEN FROM NHANVIEN WHERE SDT=@username AND MATKHAU=@password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", userName.Text);
                    command.Parameters.AddWithValue("@password", password.Text);

                    connection.Open();

                    string username = (string)command.ExecuteScalar();

                    if (username != null)
                    {
                        // User has successfully logged in
                        Main_admin adminLogin = new Main_admin();
                        adminLogin.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Invalid username or password
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }

        }
    }
}
