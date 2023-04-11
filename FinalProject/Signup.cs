using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String email = txtEmail.Text;
            String password = txtPassword.Text;


            String sdt = txtSDT.Text;
            String address = txtAddress.Text;
            // Retrieve the value from the masked textbox
            string dateValue = dateOfBirth.Text;
            // Parse the value as a DateTime object
            DateTime selectedDate = DateTime.ParseExact(dateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            // Format the date as 'yy-MM-dd'
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            
            string gioiTinh = "";
            if (rdbMale.Checked)
            {
                gioiTinh = "Male";
            }
            else if (rdbFemale.Checked)
            {
                gioiTinh = "Female";
            }


            if (checkPassword(password))
            {
                string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Insert data into the KHACHHANG table
                string insertQuery = "INSERT INTO KHACHHANG (MAKH, HOTEN, EMAIL, SDT, DIACHI, MATKHAU, GIOITINH, NGAYSINH) VALUES (dbo.GET_NEW_MAKH(),@HOTEN, @EMAIL, @SDT, @DIACHI, @MATKHAU, @GIOITINH, @NGAYSINH)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                // replace with your own logic for generating customer ID
                command.Parameters.AddWithValue("@HOTEN", name); // replace with actual name entered by user
                command.Parameters.AddWithValue("@EMAIL", email);
                command.Parameters.AddWithValue("@SDT", sdt);
                command.Parameters.AddWithValue("@DIACHI", address);
                command.Parameters.AddWithValue("@MATKHAU", password);
                command.Parameters.AddWithValue("@GIOITINH", gioiTinh); // replace with actual gender selected by user
                command.Parameters.AddWithValue("@NGAYSINH", formattedDate);
                command.ExecuteNonQuery();

                // Close the database connection
                connection.Close();

                // Display a message indicating that the customer has been added
                MessageBox.Show("Create Account Successfully!.");
            }
            else
            {
                MessageBox.Show("Password must atleast more than 8 digit and must contain at least one uppercase letter, one lowercase letter, and one digit");
            }

           

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private bool checkPassword(string password)
        {
            // Password length must be at least 8 characters
            if (password.Length < 8)
            {
                return false;
            }

            // Password must contain at least one uppercase letter, one lowercase letter, and one digit
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }
            if (!hasUppercase || !hasLowercase || !hasDigit)
            {
                return false;
            }

            // Password is valid
            return true;
        }
    }
}
