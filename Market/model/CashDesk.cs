using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class CashDesk
    {
        public int Id { get; set; }

        public CashDesk(){}

        public CashDesk(int id)
        {
            Id = id;
        }

        override
        public string ToString()
        {
            return Id.ToString();
        }
    }
}
