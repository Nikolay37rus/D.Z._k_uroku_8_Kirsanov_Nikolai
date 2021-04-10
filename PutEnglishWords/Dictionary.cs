using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutEnglishWords
{
   
    public class Dictionary : IEquatable<Dictionary>
    {
        string englishText;       
        string russianText;       

        public string EnglishText { get { return englishText; } set { if (value.GetType() == typeof(string)) englishText = value; } }
        public string RussianText { get { return russianText; } set { if (value.GetType() == typeof(string)) russianText = value; } }

       
        public bool Equals(Dictionary another)
        {
            if (this.englishText == another.englishText && this.russianText == another.russianText)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
        public Dictionary()
        {
        }

       
        public Dictionary(string engtext, string rutext)
        {
            this.englishText = engtext;
            this.russianText = rutext;
        }
    }
}
