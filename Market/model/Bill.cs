using Market.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.model
{
    internal class Bill
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public EmployeeCashDesk EmployeeCashDesk { get; set; }  

        public List<Article> Articles { get; set; }

        public Bill() 
        { 
            EmployeeCashDesk = new EmployeeCashDesk();
            Articles = new List<Article>();
        }
        public Bill(EmployeeCashDesk employeeCashDesk, List<Article> articles)
        {
            EmployeeCashDesk = employeeCashDesk;
            Articles = articles;
        }
    }
}
