using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Market.Languages
{
    [Serializable]
    public class SerbianLanguage : Language
    {
        private static string FILE = "srb1";
        public SerbianLanguage() : base(FILE)
        {
        }
    }
}
