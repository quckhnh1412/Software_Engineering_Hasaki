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
    public partial class Order : Form
    {
        User user; 
        public Order(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // Create a new instance of the TableLayoutPanel control
            int numOrders = 0;
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);

                numOrders = (int)command.ExecuteScalar();
            }
            
            tblOrder.RowCount =3;
            tblOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f)); // Set height of first row to 50 pixels
            tblOrder.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Second row will be autosized
            tblOrder.RowStyles.Add(new RowStyle(SizeType.Percent, 50f)); // Third row will take up 50% of remaining space

            Label label1 = new Label();
            label1.Text = "Row 1";
            tblOrder.Controls.Add(label1, 0, 0);

            Label label2 = new Label();
            label2.Text = "Row 2";
            tblOrder.Controls.Add(label2, 0, 1);

            Label label3 = new Label();
            label3.Text = "Row 3";
            tblOrder.Controls.Add(label3, 0, 2);



        }

        private void tblOrder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfilePage profile = new ProfilePage(user);
            profile.Show();
            this.Hide();
        }

        private void lbBrand_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(user);
            homePage.Show();
            this.Hide();
        }
    }
}
