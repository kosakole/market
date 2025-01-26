using Market.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Deliverer Deliverer { get; set; }

        public List<Article> Articles { get; set; }

        public Order() 
        {
            Articles = new List<Article>();
            Deliverer = new Deliverer();
        }

    }
}
