using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinalProject
{
    public partial class Product_detail : Form
    {
        User user;
        int productID;
        public Product_detail(User user, int productID)
        {
            InitializeComponent();
            this.user = user;
            this.productID = productID;
        }

        private void Product_detail_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";


            string query = "SELECT p.ProductName, p.Image, c.CategoryName, s.SupplierName ,p.UnitPrice,p.Description " +
                           "FROM Products p " +
                           "JOIN Categories c ON p.CategoryID = c.CategoryID " +
                           "JOIN Suppliers s ON p.SupplierID = s.SupplierID " +
                           "WHERE p.ProductID = @productId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@productId", productID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string productName = reader.GetString(0);
                    string imageFileName = reader.GetString(1);
                    string categoryName = reader.GetString(2);
                    string supplierName = reader.GetString(3);
                    int unitPrice = reader.GetInt32(4);
                    string description = reader.GetString(5);
                   
                    lbProductName.Text = WrapText( productName, lbProductName,450);
                    pictureBoxProduct.Image = Image.FromFile(@"Images\productImages\" + imageFileName);
                    lbCategory.Text = "Category: " + categoryName;
                    lbSuplier.Text = "Supplier: " + supplierName;
                    lbMoney.Text = unitPrice + " đ";
                    lbProductDescription.Text = WrapText(description, lbProductDescription,1000);
                }

                reader.Close();
            }
        }
        private string WrapText(string text, Label label, int labelWidth)
        {

            // Create a new StringBuilder object to hold the wrapped text
            StringBuilder sb = new StringBuilder();

            // Split the text into words
            string[] words = text.Split(' ');

            // Loop through each word and add it to the StringBuilder with appropriate line breaks
            int lineLength = 0;
            foreach (string word in words)
            {
                // Calculate the length of the word
                int wordLength = TextRenderer.MeasureText(word, label.Font).Width;

                // If the word doesn't fit on the current line, start a new line
                if (lineLength + wordLength > labelWidth)
                {
                    sb.Append(Environment.NewLine);
                    lineLength = 0;
                }

                // Add the word to the StringBuilder and update the line length
                sb.Append(word + " ");
                lineLength += wordLength + TextRenderer.MeasureText(" ", label.Font).Width;
            }

            // Return the wrapped text
            return sb.ToString().Trim();
        }
        private void button13_Click(object sender, EventArgs e)
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

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            user.addToCart(productID);
        }
    }
}
