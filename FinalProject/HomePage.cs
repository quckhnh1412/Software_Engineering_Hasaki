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
    public partial class HomePage : Form
    {
       
        public HomePage()
        {
            InitializeComponent();
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
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }
    }
}
