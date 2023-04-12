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
    public partial class Login : Form
    {

        User user;
        public Login()
        {
            InitializeComponent();
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void userName_Click(object sender, EventArgs e)
        {
            userName.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel6.BackColor = SystemColors.Control;
            password.BackColor = SystemColors.Control;
        }

        private void password_Click(object sender, EventArgs e)
        {
            password.BackColor = Color.White;
            panel6.BackColor = Color.White;
            userName.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbSignUpAsAdmin_Click(object sender, EventArgs e)
        {
            Admin_login adminLogin = new Admin_login();
            adminLogin.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!userName.Text.Equals("") && !password.Text.Equals(""))
            {
                string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
                string query = "SELECT CustomerID FROM Customers WHERE Phone=@username AND Password=@password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", userName.Text);
                        command.Parameters.AddWithValue("@password", password.Text);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            int customerID = (int)result;

                            // User has successfully logged in
                            user = new User(customerID);
                            HomePage homePage = new HomePage(user);
                            homePage.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Invalid username or password
                            MessageBox.Show("Invalid username or password");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }
    }
}
