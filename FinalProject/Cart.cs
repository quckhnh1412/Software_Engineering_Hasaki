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
        Dictionary<int, int> product_quantity;
        int totalAmount;
        public Cart(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            int[] ShoppingCart = user.ShoppingCart;

            product_quantity = new Dictionary<int, int>();
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            string query = "SELECT p.ProductName, p.UnitPrice, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE ProductID IN (" + string.Join(",", ShoppingCart) + ");";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < ShoppingCart.Length; i++)
                {
                    int productId = ShoppingCart[i];
                    MessageBox.Show(productId + "");
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
                        productNameLabel.Font = new Font("Microsoft Sans Serif", 9f);
                        productNameLabel.Width = 400; // set the label width to 400 pixel
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

                        // Add the quantity selector to the fourth column
                        NumericUpDown quantityNumericUpDown = new NumericUpDown();
                        quantityNumericUpDown.Minimum = 1;
                        quantityNumericUpDown.Maximum = 999;
                        quantityNumericUpDown.Value = 1;
                        quantityNumericUpDown.Font = labelFont;
                        tableLayoutCart.Controls.Add(quantityNumericUpDown, 3, row);
                        product_quantity[productId] = (int)quantityNumericUpDown.Value;

                        // Add the total price label to the fifth column
                        Label totalPriceLabel = new Label();
                        totalPriceLabel.Text = FormatCurrency(unitPrice);
                        totalPriceLabel.Font = labelFont;
                        tableLayoutCart.Controls.Add(totalPriceLabel, 4, row);
                        
                        // Attach event handler to the quantityNumericUpDown control
                        quantityNumericUpDown.ValueChanged += (a, args) => {
                            int quantity = (int)quantityNumericUpDown.Value;
                            totalPriceLabel.Text = FormatCurrency(unitPrice * quantity);
                            UpdateTotalAmount();
                            product_quantity[productId] = quantity;

                        };
                        // Add the delete button to the sixth column
                        Button deleteButton = new Button();
                        deleteButton.Text = "X";
                        deleteButton.Font = labelFont;
                        tableLayoutCart.Controls.Add(deleteButton, 5, row);

                        // Attach event handler to the delete button
                        deleteButton.Click += (a, args) =>
                        {
                            tableLayoutCart.Controls.Remove(productNameLabel);
                            tableLayoutCart.Controls.Remove(priceLabel);
                            tableLayoutCart.Controls.Remove(categoryIDLabel);
                            tableLayoutCart.Controls.Remove(quantityNumericUpDown);
                            tableLayoutCart.Controls.Remove(totalPriceLabel);
                            tableLayoutCart.Controls.Remove(deleteButton);
                            product_quantity.Remove(productId);
                            user.ShoppingCart = user.ShoppingCart.Where(x => x != productId).ToArray();
                            // Adjust the row count and total price
                            tableLayoutCart.RowCount--;
                            UpdateTotalAmount();


                        };
                        UpdateTotalAmount();
                        void UpdateTotalAmount()
                        {
                            totalAmount = 0;
                            for (int j = 0; j < tableLayoutCart.RowStyles.Count; j++)
                            {
                                Label rowTotalPriceLabel = (Label)tableLayoutCart.GetControlFromPosition(4, j);
                                if (rowTotalPriceLabel != null)
                                {
                                    totalAmount += int.Parse(rowTotalPriceLabel.Text.Replace("vnđ", "").Replace(",", ""));
                                }
                            }
                            // Update the total amount label
                            totalAmountLabel.Text = FormatCurrency(totalAmount);
                        }
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

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            if (user.ShoppingCart.Length == 0)
            {
                MessageBox.Show("Your cart is empty please add product!");
            }
            else
            {
                Checkout checkout = new Checkout(user, product_quantity, totalAmount);
                checkout.Show();
                this.Hide();
            }
            
        }
    }
}
