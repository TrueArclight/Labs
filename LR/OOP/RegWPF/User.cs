﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWPF
{
    class User
    {
        public int id { get; set; }
        public string login, pass, email;
        public User() { }
        public User(string login, string pass, string email)
        {
            this.login = login;
            this.pass = pass;
            this.email = email;
        }
    }
}
