using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace PutEnglishWords
{
   
    class CheckWord
    {
        string fileName;
        List<Dictionary> list;
        public string FileName
        {
            set { fileName = value; }
        }

        
        public CheckWord(string fileName)
        {
            this.fileName = fileName;
            list = new List<Dictionary>();
        }

        
        public void Add(string endtext, string rutext)
        {
            bool contain = list.Contains(new Dictionary(endtext, rutext));
            if (!contain)
                list.Add(new Dictionary(endtext, rutext));
            else
                MessageBox.Show("Данное слово уже имеется в списке", "Внимание");
        }

      
        public void Remove(Dictionary wordToRemove)
        {
            int index = list.IndexOf(wordToRemove);
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        
        public Dictionary this[int index]
        {
            get { return list[index]; }
        }

       
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Dictionary>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

       
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Dictionary>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Dictionary>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        
        public int Count
        {
            get { return list.Count; }
        }
    }
}
