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
    public partial class HomePage : Form
    {
        public User user;
        public HomePage(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void lbShopAll_Click(object sender, EventArgs e)
        {
            HomePage_Search homePage_Search = new HomePage_Search(user,"");
            homePage_Search.Show();
            this.Hide();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llbShopAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HomePage_Search homePage_Search = new HomePage_Search(user,"");
            homePage_Search.Show();
            this.Hide();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfilePage profile = new ProfilePage(user);
            profile.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadPopularProducts();
            LoadPopularSkincareProducts();
        }
        private void LoadPopularSkincareProducts() {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";

            string query = "SELECT TOP 10 p.ProductName, p.Image, p.UnitPrice, p.Description, p.ProductID " +
               "FROM Products p " +
               "INNER JOIN Categories c ON p.CategoryID = c.CategoryID " +
               "WHERE c.CategoryName = 'Skincare' " +
               "ORDER BY p.ProductID DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            int unitPrice = reader.GetInt32(2);
                            string imageFileName = reader.GetString(1);
                            int productId = reader.GetInt32(4);
                            // Assign the product name to the label
                            switch (i)
                            {

                                case 1:
                                    pictureBoxSkinCare1.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare1.Text = WrapText(productName, lbSkinCare1);
                                    lbSkinCarePrice1.Text = FormatCurrency(unitPrice);
                                    btnProductDetail1.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart1.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 2:
                                    pictureBoxSkinCare2.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare2.Text = WrapText(productName, lbSkinCare2);
                                    lbSkinCarePrice2.Text = FormatCurrency(unitPrice);
                                    btnProductDetail2.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart2.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 3:
                                    pictureBoxSkinCare3.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare3.Text = WrapText(productName, lbSkinCare3);
                                    lbSkinCarePrice3.Text = FormatCurrency(unitPrice);
                                    btnProductDetail3.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart3.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 4:
                                    pictureBoxSkinCare4.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare4.Text = WrapText(productName, lbSkinCare4);
                                    lbSkinCarePrice4.Text = FormatCurrency(unitPrice);
                                    btnProductDetail4.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart4.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 5:
                                    pictureBoxSkinCare5.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare5.Text = WrapText(productName, lbSkinCare5);
                                    lbSkinCarePrice5.Text = FormatCurrency(unitPrice);
                                    btnProductDetail5.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart5.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 6:
                                    pictureBoxSkinCare6.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare6.Text = WrapText(productName, lbSkinCare6);
                                    lbSkinCarePrice6.Text = FormatCurrency(unitPrice);
                                    btnProductDetail6.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart6.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 7:
                                    pictureBoxSkinCare7.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare7.Text = WrapText(productName, lbSkinCare7);
                                    lbSkinCarePrice7.Text = FormatCurrency(unitPrice);
                                    btnProductDetail7.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart7.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 8:
                                    pictureBoxSkinCare8.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare8.Text = WrapText(productName, lbSkinCare8);
                                    lbSkinCarePrice8.Text = FormatCurrency(unitPrice);
                                    btnProductDetail8.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart8.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 9:
                                    pictureBoxSkinCare9.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare9.Text = WrapText(productName, lbProductName9);
                                    lbSkinCarePrice9.Text = FormatCurrency(unitPrice);
                                    btnProductDetail9.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart9.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 10:
                                    pictureBoxSkinCare10.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbSkinCare10.Text = WrapText(productName, lbSkinCare10);
                                    lbSkinCarePrice10.Text = FormatCurrency(unitPrice);
                                    btnProductDetail10.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCart10.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                            }

                            i++;
                        }
                    }

                    reader.Close();
                }
            }
        }
        private void LoadPopularProducts()
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";

            string query = "SELECT TOP 10 ProductName, Image, UnitPrice, Description,ProductID FROM Products ORDER BY ProductID DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            int unitPrice = reader.GetInt32(2);
                            string imageFileName = reader.GetString(1);
                            int productId=reader.GetInt32(4);
                            // Assign the product name to the label
                            switch (i)
                            {

                                case 1:
                                    pictureBoxProduct1.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName1.Text = WrapText(productName, lbProductName1);
                                    lbProductPrice1.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail1.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC1.Click += (sender, e) => { user.addToCart(productId); };

                                    break;
                                case 2:
                                    pictureBoxProduct2.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName2.Text = WrapText(productName, lbProductName2);
                                    lbProductPrice2.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail2.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC2.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 3:
                                    pictureBoxProduct3.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName3.Text = WrapText(productName, lbProductName3);
                                    lbProductPrice3.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail3.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC3.Click += (sender, e) => { user.addToCart(productId); };

                                    break;
                                case 4:
                                    pictureBoxProduct4.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName4.Text = WrapText(productName, lbProductName4);
                                    lbProductPrice4.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail4.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC4.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 5:
                                    pictureBoxProduct5.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName5.Text = WrapText(productName, lbProductName5);
                                    lbProductPrice5.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail5.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC5.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 6:
                                    pictureBoxProduct6.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName6.Text = WrapText(productName, lbProductName6);
                                    lbProductPrice6.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail6.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC6.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 7:
                                    pictureBoxProduct7.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName7.Text = WrapText(productName, lbProductName7);
                                    lbProductPrice7.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail7.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC7.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 8:
                                    pictureBoxProduct8.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName8.Text = WrapText(productName, lbProductName8);
                                    lbProductPrice8.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail8.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC8.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 9:
                                    pictureBoxProduct9.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName9.Text = WrapText(productName, lbProductName9);
                                    lbProductPrice9.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail9.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC9.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                                case 10:
                                    pictureBoxProduct10.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName10.Text = WrapText(productName, lbProductName10);
                                    lbProductPrice10.Text = FormatCurrency(unitPrice);
                                    btnSkincareDetail10.Click += (sender, e) => sendToDetailPage(this.user, productId);
                                    btnAddToCartSC10.Click += (sender, e) => { user.addToCart(productId); };
                                    break;
                            }

                            i++;
                        }
                    }

                    reader.Close();
                }
            }
        }
        private void sendToDetailPage(User user, int productId)
        {

            Product_detail product_Detail = new Product_detail(user, productId);
            product_Detail.Show();
            this.Hide();

        }
        private string WrapText(string text, Label label)
        {
            // Get the width of the label
            int labelWidth = 200;

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

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        public string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + " vnđ";
        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(user);
            cart.Show();
            this.Hide();
        }

        private void pannelSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text;
            HomePage_Search homePage_Search = new HomePage_Search(user, searchText);
            homePage_Search.Show();
            this.Hide();
        }

        private void pictureBoxSeach_Click(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text;
            HomePage_Search homePage_Search = new HomePage_Search(user, searchText);
            homePage_Search.Show();
            this.Hide();
        }
    }
}
