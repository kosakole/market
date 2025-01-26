using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    public interface AdminDAO
    {
        bool check(string username, string password);
    }
}
