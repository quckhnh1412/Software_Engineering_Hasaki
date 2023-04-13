using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Cart : Form
    {
        User user;
        public Cart(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            int[] ShoppingCart = user.ShoppingCart;

            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            string query = "SELECT p.ProductName, p.UnitPrice, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE ProductID IN (" + string.Join(",", ShoppingCart) + ");";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < ShoppingCart.Length; i++)
                {
                    int productId = ShoppingCart[i];
                    SqlCommand command = new SqlCommand("SELECT p.ProductName, c.CategoryName, p.UnitPrice FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.ProductID = @ProductId", connection);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        string categoryName = (string)reader["CategoryName"];
                        int unitPrice = (int)reader["UnitPrice"];

                        int row = tableLayoutCart.RowCount++;
                        tableLayoutCart.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                        Font labelFont = new Font("Microsoft Sans Serif", 10f);

                        // Add the product name label to the first column
                        Label productNameLabel = new Label();
                        productNameLabel.Text = productName;
                        productNameLabel.Font = labelFont;
                        productNameLabel.Width = 400; // set the label width to 400 pixels
                        tableLayoutCart.Controls.Add(productNameLabel, 0, row);

                        // Add the price label to the second column
                        Label priceLabel = new Label();
                        priceLabel.Text = FormatCurrency(unitPrice);
                        priceLabel.Font = labelFont;
                        tableLayoutCart.Controls.Add(priceLabel, 1, row);

                        // Add the category ID label to the third column
                        Label categoryIDLabel = new Label();
                        categoryIDLabel.Text = categoryName.ToString();
                        categoryIDLabel.Font = labelFont;
                        tableLayoutCart.Controls.Add(categoryIDLabel, 2, row);
                    }

                    reader.Close();
                }
            }
        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            ProfilePage profilePage = new ProfilePage(user);
            profilePage.Show();
            this.Hide();
        }

        private void lbBrand_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(user);
            homePage.Show();
            this.Hide();
        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }
        public string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + " vnđ";
        }
    }
}
