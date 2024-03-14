using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronicStore.WPF
{
    class User
    {
        private uint id { get; set; }

        private string login, pass, email;

        public User() { }

        public User(string login, string pass, string email)
        {
            this.pass = pass;
            this.email = email;
        }
    }
}
