using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    internal class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }

        public bool Employed { get; set; }

        public UserDTO() { }

        public UserDTO(string id, string firstName, string lastName, string username)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }

        public UserDTO(string id, string firstName, string lastName, string username, bool emp)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Employed = emp;
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Employed = user.Employed;
        }

        override
        public string ToString()
        {
            return Username;
        }
    }
}
