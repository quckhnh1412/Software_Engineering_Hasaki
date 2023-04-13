using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class User
    {
        public int UserID { get; set; }
        public int[] ShoppingCart { get; set; }

        public User(int userID)
        {
            UserID = userID;
        }

        public void addToCart(int itemID)
        {
            if (ShoppingCart == null)
            {
                ShoppingCart = new int[] { itemID };
                MessageBox.Show("Add to cart successful!!");
            }
            else
            {
                List<int> items = new List<int>(ShoppingCart);
                items.Add(itemID);
                ShoppingCart = items.ToArray();
                MessageBox.Show("Add to cart successful!!");
            }
        }

        public void signOut()
        {
            ShoppingCart = null;
            UserID = -1;
            Login login = new Login();
            login.Show();

        }



    }
}
