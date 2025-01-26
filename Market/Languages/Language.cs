using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Languages
{
    [Serializable]
    public abstract class Language
    {
        public Dictionary<string, string> Words {  get; set; }
        private string file;
        protected static string ERROR = "Error";
        protected static string MUST_BE_POSITIVE_NUMBER = "A1";
        protected static string NOT_VALID_FIELD = "is not a valid field!";
        protected static string FILD = "Field";
        public Language() { }
        protected Language(string file) 
        {
            this.file = file;
            initMap();
        }

        public void initMap()
        {
            Words = new Dictionary<string, string>();
            StreamReader reader = new StreamReader("Language/" + file + ".csv");
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = line.Split('|');
                if (!Words.ContainsKey(splitLine[0])) 
                    Words.Add(splitLine[0], splitLine[1]);
            }
            reader.Close();
        }

        public string notValidFild(string s)
        {
            string s1 = Words.ContainsKey(FILD) ? Words[FILD] : "";
            string s2 = Words.ContainsKey(s) ? Words[s] : "";
            string s3 = Words.ContainsKey(NOT_VALID_FIELD) ? Words[NOT_VALID_FIELD] : ""; ;
            return s1 + " " + s2 + " " + s3;
        }

        public string notNegativ(string s)
        {
            
            try
            {
                return Words[FILD] + " " + Words[s] + " " + Words[MUST_BE_POSITIVE_NUMBER];
            }
            catch
            (Exception e)
            {
                return "";
            }
        }
    }
}
