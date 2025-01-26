using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class Deliverer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
