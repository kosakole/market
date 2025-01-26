using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Languages
{
    [Serializable]
    public class EnglishLanguage : Language
    {
        private static string FILE = "eng";
        public EnglishLanguage() : base(FILE)
        {
        }
    }
}
