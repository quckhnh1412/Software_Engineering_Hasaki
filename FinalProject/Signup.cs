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
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            String sdt = txtSDT.Text;
            String address = txtAddress.Text;
            DateTime selectedDate = dateOfBirth.Value;
            // Format the date as 'yy-MM-dd'
            string formattedDate = selectedDate.ToString("yy-MM-dd");
            string gioiTinh = "";
            if (rdbMale.Checked)
            {
                gioiTinh = "Male";
            }
            else if (rdbFemale.Checked)
            {
                gioiTinh = "Female";
            }

            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Insert data into the KHACHHANG table
            string insertQuery = "INSERT INTO KHACHHANG (MAKH, HOTEN, EMAIL, SDT, DIACHI, MATKHAU, GIOITINH, NGAYSINH) VALUES (dbo.GET_NEW_MAKH(),@HOTEN, @EMAIL, @SDT, @DIACHI, @MATKHAU, @GIOITINH, @NGAYSINH)";
            SqlCommand command = new SqlCommand(insertQuery, connection);
 // replace with your own logic for generating customer ID
            command.Parameters.AddWithValue("@HOTEN", "Full Name"); // replace with actual name entered by user
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
            MessageBox.Show("Customer added successfully.");

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
