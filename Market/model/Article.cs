using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DTO
{
    public class Article
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public Article()
        { }

        public Article(string barcode, string name, decimal price, decimal amount)
        {
            this.Barcode = barcode;
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }
    }
}
