using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Donny
{
    public class Database
    {
        public class Entry
        {
            [XmlIgnore]
            public string[] keywords;
            [XmlElement("keywords")]
            public string keywordsAsString;
            public string answer;

            public Entry()
            {

            }

            public Entry(string[] keywords, string answer)
            {
                this.keywords = keywords;
                keywordsAsString = string.Join(",", keywords);
                this.answer = answer;
            }
        }

        
        List<Entry> database;
        List<Entry> temporaryMemory;

        public Database()
        {
            //Deserialize
            FileStream fs = new FileStream("DonnyDatabase.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            database = (List<Entry>)serializer.Deserialize(fs);
            fs.Close();
            foreach(Entry e in database)
            {
                e.keywords = e.keywordsAsString.Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
            }
            
            // //serialize
            //database.Add(new Entry(new string[] { "a", "b", "c" }, "1"));
            //fs = new FileStream("DonnyDatabase.xml", FileMode.Create);
            //serializer.Serialize(fs, database);
            //fs.Close();
            //database.Clear();
        }

        //returns true of word is a keyword according to the database
        public bool IdentifyKeyword(string word)
        {
            throw new NotImplementedException();
        }
        
        //returns best fitting answer from the database based on the keywords
        public string GetAnswer(string[] keywords)
        {
            throw new NotImplementedException();
        }

        public void Remember()
        {
            throw new NotImplementedException();
        }

        public void Forget()
        {
            throw new NotImplementedException();
        }
    }
}
