using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Manager
    {
        User user; 
        public Manager(User user) { 
            this.user = user;
        }

        public void signOut()
        {
            user.ShoppingCart = null;
            user.UserID = "";
            Login login = new Login();
            login.Show();

        }
        public void openMainPage()
        {
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        public void openProfilePage()
        {
            // code to open the profile page
            ProfilePage profile = new ProfilePage();
            profile.Show();
        }
    }
}
