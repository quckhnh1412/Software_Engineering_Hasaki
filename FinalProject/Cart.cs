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
    public partial class Cart : Form
    {
        User user;
        public Cart(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Cart_Load(object sender, EventArgs e)
        {

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
    }
}
