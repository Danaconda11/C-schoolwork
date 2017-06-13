using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedLab3
{
    class Movie : Media, IEncryptable 
    {
        public string Director { get; set; }
        public string Summary { get; set; }

        public Movie(string title, int year, string Director, string Summary) : base(title,year)
        {
            this.Title = title;
            this.Year = year;
            this.Director = Director;
            this.Summary = Summary;
        }

        public string Decrypt()
        {
            //ROT13 decryptions
            //http://www.datavoila.com/projects/text/rot13-encrypt-decrypt-a-text.html
            StringBuilder result = new StringBuilder();
            Regex regex = new Regex("[A-Za-z]");

            foreach (char c in Summary)
            {
                if (regex.IsMatch(c.ToString()))
                {
                    int charCode = ((c & 223) - 52) % 26 + (c & 32) + 65;
                    result.Append((char)charCode);
                }
                else
                {
                    result.Append(c);
                }
            }

            string value = result.ToString();
            return value;
        }

        public string Encrypt()
        {
            return "";
        }
    }   
}
