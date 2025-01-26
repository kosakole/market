using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface EmployeeCashDeskDAO
    {
        EmployeeCashDesk getNext(UserDTO user, CashDesk cash);
        List<EmployeeCashDesk> GetAll();
    }
}
