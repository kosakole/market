using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Employed { get; set; }

        public User()
        {
            Employed = true;
        }

        public User(string id, string firstName, string lastName, string username, string password):this() 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public User(string id, string firstName, string lastName, string username, string password, bool employed)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Employed = employed;
        }

        public string ToString()
        {
            string ret = this.Id + " " + this.FirstName + " " + this.LastName;
            return ret;
        }
    }
}
