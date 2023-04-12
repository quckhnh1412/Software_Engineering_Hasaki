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
    public partial class ProfilePage : Form
    {
        public User user;
        public ProfilePage()
        {
            InitializeComponent();
        }
        public ProfilePage(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void lbSignOut_Click(object sender, EventArgs e)
        {
            user.signOut();
            this.Hide();
        }

        private void ProfilePage_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Customers WHERE CustomerID = @customerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", user.UserID);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string name = reader["Name"].ToString();
                lbName.Text = name;
                tbName.Text = name;
                if (tbName.Text.Length > tbName.MaxLength)
                {
                    string[] lines = SplitTextIntoLines(tbName.Text, tbName.MaxLength);
                    tbName.Lines = lines;
                }
                string email = reader["Email"].ToString();
                tbEmail.Text = email;
                string phone = reader["Phone"].ToString();
                tbPhone.Text = phone;
                string address = reader["Address"].ToString();
                tbAddress.Text = address;
                string password = reader["Password"].ToString();
                tbPassword.Text = password;
                string gender = reader["Gender"].ToString();
                DateTime birthday = (DateTime)reader["Birthday"];

                // Do something with the retrieved data...
            }
            reader.Close();
            connection.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the text boxes
            string name = tbName.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;
            string address = tbAddress.Text;
            string password = tbPassword.Text;
            int customerId = user.UserID; // Replace with the actual customer ID

            // Update the values in the SQL database
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Customers SET Name = @name, Email = @email, Phone = @phone, Address = @address, Password = @password WHERE CustomerID = @customerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@customerId", customerId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Customer information updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update customer information.");
            }
        }

        private string[] SplitTextIntoLines(string text, int maxLength)
        {
            List<string> lines = new List<string>();
            while (text.Length > maxLength)
            {
                int i = maxLength;
                while (i > 0 && !char.IsWhiteSpace(text[i]))
                    i--;
                if (i == 0)
                    i = maxLength;
                lines.Add(text.Substring(0, i).TrimEnd());
                text = text.Substring(i);
            }
            lines.Add(text);
            return lines.ToArray();
        }
    }
}
