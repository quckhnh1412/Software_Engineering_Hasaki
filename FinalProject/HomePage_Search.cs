using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class HomePage_Search : Form
    {
        User user;
        string productName = "";
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
        public HomePage_Search(User user, string productName)
        {
            InitializeComponent();
            this.user = user;
            this.productName = productName;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(user);
            cart.Show();
            this.Hide();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfilePage profile = new ProfilePage(user);
            profile.Show();
            this.Hide();
        }

        private void HomePage_Search_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE ProductName LIKE '%' + @productName + '%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int panelIndex = 0;
                        panelContainer.AutoScroll = true;

                        while (reader.Read())
                        {
                            // Access data in the reader
                            int productId = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            string imageFileName = reader.GetString(2);
                            int unitPrice = reader.GetInt32(5);

                            createNewPanel(productId, productName, imageFileName, unitPrice);

                        }

                       
                    }
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

        private void radHighestPrice_CheckedChanged(object sender, EventArgs e)
        {
            // Update the SQL query to order by UnitPrice in descending order
            string query = "SELECT * FROM Products WHERE ProductName LIKE '%' + @productName + '%' ORDER BY UnitPrice ASC";

            // Execute the query and populate the panelContainData with the results
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        panelContainer.Controls.Clear();
                        panelContainer.AutoScroll = true;

                        while (reader.Read())
                        {
                            // Access data in the reader
                            int productId = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            string imageFileName = reader.GetString(2);
                            int unitPrice = reader.GetInt32(5);

                            createNewPanel(productId, productName, imageFileName, unitPrice);
                        }
                    }
                }
            }
        }
        public void createNewPanel(int productId, string productName, string imageFileName, int unitPrice)
        {
            // Create a new panel
            Panel panelProductNew = new Panel();
            panelProductNew.Dock = DockStyle.Left;

            panelProductNew.Size = new Size(246, 395);
            panelProductNew.Margin = new Padding(50);

            // Create and set the image of the product
            PictureBox pbProductImageNew = new PictureBox();
            pbProductImageNew.Image = Image.FromFile(@"C:\Users\HP\source\repos\Picture\productImages\" + imageFileName);
            pbProductImageNew.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProductImageNew.Size = new Size(246, 240);
            pbProductImageNew.Location = new Point(0, 0);
            panelProductNew.Controls.Add(pbProductImageNew);

            // Create and set the name of the product
            Label lbProductNameNew = new Label();
            lbProductNameNew.Text = WrapText(productName, lbProductNameNew);
            lbProductNameNew.AutoSize = true;
            lbProductNameNew.Location = new Point(5, pbProductImageNew.Bottom);
            lbProductNameNew.Font = new Font("Arial", 10.8f);
            panelProductNew.Controls.Add(lbProductNameNew);

            // Create and set the price of the product
            Label lbProductPriceNew = new Label();
            lbProductPriceNew.Text = unitPrice + " đ";
            lbProductPriceNew.AutoSize = true;
            lbProductPriceNew.Location = new Point(5, lbProductNameNew.Bottom + 25);
            lbProductPriceNew.Font = new Font("Arial", 10.8f);
            lbProductPriceNew.ForeColor = Color.Red;
            panelProductNew.Controls.Add(lbProductPriceNew);

            Button btnAddToCartNew = new Button();
            btnAddToCartNew.Text = "ADD";
            btnAddToCartNew.FlatStyle = FlatStyle.Flat;
            btnAddToCartNew.BackColor = Color.FromArgb(0, 160, 45);
            btnAddToCartNew.ForeColor = Color.White;
            btnAddToCartNew.Font = new Font("Century Gothic", 10.2f, FontStyle.Bold);
            btnAddToCartNew.Size = new Size(100, 38);
            btnAddToCartNew.Location = new Point(0, lbProductPriceNew.Bottom + 5);
            panelProductNew.Controls.Add(btnAddToCartNew);

            Button btnProductDetailNew = new Button();
            btnProductDetailNew.Text = "DETAIL";
            btnProductDetailNew.FlatStyle = FlatStyle.Flat;
            btnProductDetailNew.BackColor = Color.Blue;
            btnProductDetailNew.ForeColor = Color.White;
            btnProductDetailNew.Font = new Font("Century Gothic", 10.2f, FontStyle.Bold);
            btnProductDetailNew.Size = new Size(100, 38);
            btnProductDetailNew.Location = new Point(btnAddToCartNew.Right, btnAddToCartNew.Top);
            panelProductNew.Controls.Add(btnProductDetailNew);
            // Set the AutoScrollMinSize property
            panelContainer.AutoScrollMinSize = new Size(panelProductNew.Right + 10, panelContainer.ClientSize.Height);
            // Add the new panel to the container and set its location
            panelContainer.Controls.Add(panelProductNew);
        }

        private void redLowestPrice_CheckedChanged(object sender, EventArgs e)
        {
            // Update the SQL query to order by UnitPrice in descending order
            string query = "SELECT * FROM Products WHERE ProductName LIKE '%' + @productName + '%' ORDER BY UnitPrice DESC";

            // Execute the query and populate the panelContainData with the results
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        panelContainer.Controls.Clear();
                        panelContainer.AutoScroll = true;

                        while (reader.Read())
                        {
                            // Access data in the reader
                            int productId = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            string imageFileName = reader.GetString(2);
                            int unitPrice = reader.GetInt32(5);

                            createNewPanel(productId, productName, imageFileName, unitPrice);
                        }
                    }
                }
            }
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {

        }

        private void lbBrand_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(user);
            homePage.Show();
            this.Hide();
        }
    }
}
