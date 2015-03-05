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
            [XmlElement("keyword")]
            public string[] keywords;
            public string answer;

            public Entry()
            {

            }

            public Entry(string[] keywords, string answer)
            {
                this.keywords = keywords;
                this.answer = answer;
            }
        }

        
        List<Entry> database;
        List<Entry> temporaryMemory;

        public Database()
        {
            // initialize database
            database = new List<Entry>();

            FileStream fs;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));

            /*
             * //Serialize
            database.Add(new Entry(new string[] { "a", "b", "c" }, "1"));
            fs = new FileStream("TestDatabase.xml", FileMode.Create);
            serializer.Serialize(fs, database);
            database.Clear();
            fs.Close();
            */

            //Deserialize
            fs = new FileStream("TestDatabase.xml", FileMode.Open);
            database = (List<Entry>)serializer.Deserialize(fs);
            fs.Close();
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
