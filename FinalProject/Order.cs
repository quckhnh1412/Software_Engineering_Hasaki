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
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
        public Order(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // Clear the existing controls in tblOrders
            tblOrders.Controls.Clear();
            tblOrders.RowStyles.Clear();

            // Add column headers
            Label lblOrderID = new Label() { Text = "Order ID", TextAlign = ContentAlignment.MiddleCenter };
            Label lblOrderDate = new Label() { Text = "Order Date", TextAlign = ContentAlignment.MiddleCenter };
            Label lblShippingMethod = new Label() { Text = "Shipping Method", TextAlign = ContentAlignment.MiddleCenter };
            Label lblOrderStatus = new Label() { Text = "Order Status", TextAlign = ContentAlignment.MiddleCenter };
            Label lblTotalAmount = new Label() { Text = "Total Amount", TextAlign = ContentAlignment.MiddleCenter };

            Font labelFont = new Font("Arial", 10.8f, FontStyle.Bold);
            lblOrderID.Font = labelFont;
            lblOrderDate.Font = labelFont;
            lblShippingMethod.Font = labelFont;
            lblTotalAmount.Font = labelFont;
            lblOrderStatus.Font = labelFont;

            tblOrders.Controls.Add(lblOrderID, 0, 0);
            tblOrders.Controls.Add(lblOrderDate, 1, 0);
            tblOrders.Controls.Add(lblShippingMethod, 2, 0);
            tblOrders.Controls.Add(lblOrderStatus, 3, 0);
            tblOrders.Controls.Add(lblTotalAmount, 4, 0);

            // Get the orders where OrderStatus is "on the way" from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT OrderID, OrderDate, ShippingMethod, OrderStatus, TotalAmount " +
                    "FROM Orders " +
                    "WHERE OrderStatus = 'on the way'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int row = 1;
                        while (reader.Read())
                        {
                            // Create the labels to display the order information
                            Label lblOrderIDValue = new Label() { Text = reader["OrderID"].ToString(), TextAlign = ContentAlignment.MiddleCenter };
                            Label lblOrderDateValue = new Label() { Text = reader["OrderDate"].ToString(), TextAlign = ContentAlignment.MiddleCenter };
                            Label lblShippingMethodValue = new Label() { Text = reader["ShippingMethod"].ToString(), TextAlign = ContentAlignment.MiddleCenter };
                            Label lblOrderStatusValue = new Label() { Text = reader["OrderStatus"].ToString(), TextAlign = ContentAlignment.MiddleCenter };
                            Label lblTotalAmountValue = new Label() { Text = reader["TotalAmount"].ToString(), TextAlign = ContentAlignment.MiddleCenter };
                            Button btnAction = new Button() { Text = "View Details", TextAlign = ContentAlignment.MiddleCenter };

                            Font textFont = new Font("Arial", 10.8f);
                            lblOrderIDValue.Font = textFont;
                            lblOrderDateValue.Font = textFont;
                            lblShippingMethodValue.Font = textFont;
                            lblOrderStatusValue.Font = textFont;
                            lblTotalAmountValue.Font = textFont;
                            

                            // Add the labels to the table layout panel
                            tblOrders.Controls.Add(lblOrderIDValue, 0, row);
                            tblOrders.Controls.Add(lblOrderDateValue, 1, row);
                            tblOrders.Controls.Add(lblShippingMethodValue, 2, row);
                            tblOrders.Controls.Add(lblOrderStatusValue, 3, row);
                            tblOrders.Controls.Add(lblTotalAmountValue, 4, row);
                            tblOrders.Controls.Add(btnAction, 5, row);

                            int orderID = (int)reader["OrderID"];
                            btnAction.Click += (arg, u) =>
                            {
                                OpenOrderDetail(orderID);
                            };

                                // Increment the row index
                                row++;
                        }
                    }
                }
            }

  
        }

        private void OpenOrderDetail(int orderID)
        {
            OrderDetail orderDetail = new OrderDetail(orderID);
            orderDetail.Show();
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

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text;
            HomePage_Search homePage_Search = new HomePage_Search(user, searchText);
            homePage_Search.Show();
            this.Hide();
        }
    }
}
