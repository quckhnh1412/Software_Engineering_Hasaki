using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class User
    {
        public String UserID { get; set; }
        public string[] ShoppingCart { get; set; }

        public User(String userID)
        {
            UserID = userID;
        }



    }
}
