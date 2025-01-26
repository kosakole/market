using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class EmployeeCashDesk
    {

        public int ID { get; set; }
        public CashDesk CashDesk { get; set; }
        public UserDTO User { get; set; }
        public DateTime Created { get; set; }

        public EmployeeCashDesk() 
        {
            CashDesk = new CashDesk();
            User = new UserDTO();
        }

        public EmployeeCashDesk(CashDesk cashDesk, UserDTO user) 
        {
            CashDesk = cashDesk;
            User = user;
        }


    }
}
