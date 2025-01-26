using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface BillDAO
    {
        bool create(Bill bill);
        List<Bill> GetAll();
        Bill GetBill(int id);

        bool delete(int id);
    }
}
