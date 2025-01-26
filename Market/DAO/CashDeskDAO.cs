using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface CashDeskDAO
    {
        CashDesk creat();
        List<CashDesk> GetAll();
        int getNextID();
    }
}
