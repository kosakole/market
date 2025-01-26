using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface UserDAO
    {
        List<UserDTO> GetAll();
        UserDTO GetUser(string id);
        bool AddUser(User user);
        bool UpdateUser(UserDTO user, string id);
        bool DeleteUser(UserDTO user);

        bool changePassword(UserDTO user, string pass);

    }
}
