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
    public partial class OrderDetail : Form
    {
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
        int orderID;
        public OrderDetail(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            // Clear the existing controls in tblOrderDetail
            tblOrderDetail.Controls.Clear();
            tblOrderDetail.RowStyles.Clear();

            // Add column headers
            Label lblHeader = new Label() { Text = "Header", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10.8f, FontStyle.Bold) };
            lblHeader.Margin = new Padding(0, 0, 0, 20);

            tblOrderDetail.Controls.Add(lblHeader, 0, 0);

            Label lblValue = new Label() { Text = "Value", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10.8f, FontStyle.Bold) };
            lblValue.Margin = new Padding(0, 0, 0, 20);
            tblOrderDetail.Controls.Add(lblValue, 1, 0);
            // Set the margin of the labels to add a bottom margin of 20
          


            // Get the order details from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT OrderDate, CustomerID, ShippingMethod, ShippingFee, OrderStatus, TotalAmount, dbo.GetOrderDetails(OrderID) AS OrderDetails " +
                    "FROM Orders " +
                    "WHERE OrderID = @OrderID", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int row = 1;
                        Font textFont = new Font("Arial", 10.8f);
                        while (reader.Read())
                        {
                            // Add the order detail data to the table layout panel
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // Create the labels to display the order detail data
                                Label lblHeaderName = new Label() { Text = reader.GetName(i), TextAlign = ContentAlignment.MiddleLeft };
                                Label lblValueName = new Label() { Text = reader.GetValue(i).ToString(), TextAlign = ContentAlignment.MiddleLeft };
                                lblHeaderName.Font = textFont;
                                lblValueName.Font = textFont;
                                lblValueName.AutoSize = true;

                                // Set the margin of the labels to add a bottom margin of 20
                                lblHeaderName.Margin = new Padding(0, 0, 0, 20);
                                lblValueName.Margin = new Padding(0, 0, 0, 20);


                                // Add the labels to the table layout panel
                                tblOrderDetail.Controls.Add(lblHeaderName, 0, row);

                                if (reader.GetName(i) == "OrderDetails")
                                {
                                    string orderDetails = reader.GetValue(i).ToString();
                                    string[] products = orderDetails.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                    Label lblProductList = new Label() { Text = "", TextAlign = ContentAlignment.MiddleLeft };

                                    foreach (string product in products)
                                    {
                                        string[] productParts = product.Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                                        string productName = productParts[0].Trim();
                                        string productQuantity = productParts[1].Replace(")", "").Trim();
                                        lblProductList.Text += $"{productName} ({productQuantity})\n";
                                    }

                                    lblProductList.AutoSize = true;
                                    lblProductList.Font = textFont;
                                    tblOrderDetail.Controls.Add(lblProductList, 1, row);
                                }
                                else
                                {
                                    tblOrderDetail.Controls.Add(lblValueName, 1, row);
                                }

                                // Increment the row index
                                row++;
                            }
                        }
                    }
                }
            }



        }
    }
}
