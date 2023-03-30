using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Login : Form
    {
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
    }
}
