﻿using System;
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
    public partial class Checkout : Form
    {
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
        User user;
        Dictionary<int, int> product_quantity;
        int totalAmout;
        public Checkout(User user, Dictionary<int, int> product_quantity,int totalAmout)
        {
            InitializeComponent();
            this.user = user;
            this.product_quantity = product_quantity;
            this.totalAmout = totalAmout;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {

            totalAmountLabel.Text = FormatCurrency(totalAmout);
            LoadProductName();
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString("dddd, MMMM d, yyyy h:mm tt");
            lbDateTime.Text = dateTimeString;
            string query = $"SELECT Name, Address FROM Customers WHERE CustomerID = {user.UserID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // retrieve the name and address values from the reader
                    string name = reader.GetString(0);
                    string address = reader.GetString(1);

                    // set the name and address labels to the retrieved values
                    lbCustomerName.Text = name;
                    lbCustomerAddress.Text = address;
                }

                reader.Close();
            }


        }
        public string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + " vnđ";
        }
        private void LoadProductName()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < user.ShoppingCart.Length; i++)
                {
                    int productId = user.ShoppingCart[i];
                    SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductID = @ProductId", connection);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];

                        int row = tableLayoutProduct.RowCount++;
                        tableLayoutProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                        Font labelFont = new Font("Microsoft Sans Serif", 8f);

                        // Add the product name label to the first column
                        Label productNameLabel = new Label();
                        productNameLabel.Text = productName;
                        productNameLabel.Font = labelFont;
                        productNameLabel.Width = 400; // set the label width to 400 pixel
                        tableLayoutProduct.Controls.Add(productNameLabel, 0, row);

                        // Add other columns as needed

                        reader.Close();
                    }
                }
            }
        }

        private void lbHomepage_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(user);
            homePage.Show();
            this.Hide();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfilePage profilePage = new ProfilePage(user);
            profilePage.Show();
            this.Hide();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text;
            HomePage_Search homePage_Search = new HomePage_Search(user, searchText);
            homePage_Search.Show();
            this.Hide();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(user);
            cart.Show();
            this.Hide();
        }

        private void rdbNormalShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNormalShipping.Checked)
            {
                lbShippingCost.Text = FormatCurrency(15000);
                lbOverall.Text = FormatCurrency(15000 + totalAmout);
            }
        }

        private void rdbFastShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFastShipping.Checked)
            {
                lbShippingCost.Text = FormatCurrency(25000);
                lbOverall.Text = FormatCurrency(25000 + totalAmout);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check if either of the radio buttons is checked
            if (!rdbNormalShipping.Checked && !rdbFastShipping.Checked)
            {
                MessageBox.Show("Please choose a shipping method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if no shipping method is selected
            }

        }
    }
}
