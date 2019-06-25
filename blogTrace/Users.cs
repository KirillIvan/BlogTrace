using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogTrace
{
    public class Users
    {
        public List<User> items;

        public Users()
        {
            items = new List<User>();
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public User()
        { }
        public User(string login, string pswd, bool admin)
        {
            Login = login;
            Password = pswd;
            Admin = admin;
        }
    }
}
