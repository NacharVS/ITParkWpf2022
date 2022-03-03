using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkWPF
{
    class User
    {
        public User(string name, string login, string email, string phoneNumber)
        {
            Name = name;
            Login = login;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
