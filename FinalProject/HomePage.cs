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
            HomePage_Search homePage_Search = new HomePage_Search();
            homePage_Search.Show();
            this.Hide();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llbShopAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HomePage_Search homePage_Search = new HomePage_Search();
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
        }
        private void LoadPopularProducts()
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";

            string query = "SELECT TOP 10 ProductName, Image, UnitPrice, Description FROM Products ORDER BY ProductID DESC";

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
                            // Assign the product name to the label
                            switch (i)
                            {

                                case 1:
                                    pictureBoxProduct1.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName1.Text = WrapText(productName, lbProductName1);
                                    lbProductPrice1.Text = unitPrice + " đ";
                                    break;
                                case 2:
                                    pictureBoxProduct2.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName2.Text = WrapText(productName, lbProductName2);
                                    lbProductPrice2.Text = unitPrice + " đ";
                                    break;
                                case 3:
                                    pictureBoxProduct3.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName3.Text = WrapText(productName, lbProductName3);
                                    lbProductPrice3.Text = unitPrice + " đ";
                                    break;
                                case 4:
                                    pictureBoxProduct4.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName4.Text = WrapText(productName, lbProductName4);
                                    lbProductPrice4.Text = unitPrice + " đ";
                                    break;
                                case 5:
                                    pictureBoxProduct5.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName5.Text = WrapText(productName, lbProductName5);
                                    lbProductPrice5.Text = unitPrice + " đ";
                                    break;
                                case 6:
                                    pictureBoxProduct6.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName6.Text = WrapText(productName, lbProductName6);
                                    lbProductPrice6.Text = unitPrice + " đ";
                                    break;
                                case 7:
                                    pictureBoxProduct7.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName7.Text = WrapText(productName, lbProductName7);
                                    lbProductPrice7.Text = unitPrice + " đ";
                                    break;
                                case 8:
                                    pictureBoxProduct8.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName8.Text = WrapText(productName, lbProductName8);
                                    lbProductPrice8.Text = unitPrice + " đ";
                                    break;
                                case 9:
                                    pictureBoxProduct9.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName9.Text = WrapText(productName, lbProductName9);
                                    lbProductPrice9.Text = unitPrice + " đ";
                                    break;
                                case 10:
                                    pictureBoxProduct10.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
                                    lbProductName10.Text = WrapText(productName, lbProductName10);
                                    lbProductPrice10.Text = unitPrice + " đ";
                                    break;
                            }

                            i++;
                        }
                    }

                    reader.Close();
                }
            }
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
    }
}
