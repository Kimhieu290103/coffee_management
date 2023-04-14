using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.Model
{
    public class UserAccount
    {
        private string userName;
        private string password;
        private byte role;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public byte Role { get => role; set => role = value; }

        public override bool Equals(object obj)
        {
            return obj is UserAccount account &&
                   userName == account.userName &&
                   password == account.password &&
                   role == account.role;
        }
    }
}