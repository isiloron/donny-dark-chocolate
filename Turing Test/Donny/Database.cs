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
            [XmlIgnore]
            public bool used;

            public Entry()
            {
                used = false;
            }

            public Entry(string[] keywords, string answer)
            {
                this.keywords = keywords;
                keywordsAsString = string.Join(",", keywords);
                this.answer = answer;
                used = false;
            }

            public void UseQuestion()
            {
                used = true;
            }

            public bool Used
            {
                get { return used; }
            }
        }

        public struct FoundAnswer : IComparable<FoundAnswer>
        {
            Entry entry;
            int relevance;

            public FoundAnswer(Entry entry)
            {
                this.entry = entry;
                relevance = 0;
            }

            public void IncreaseRelevance() {
                ++relevance;
            } 

            public int CompareTo(FoundAnswer other)
            {
                if (relevance < other.relevance)
                {
                    return 1;
                }
                else if (relevance > other.relevance)
                {
                    return -1;
                } else {
                    return 0;
                }
            }

            public int Relevance
            {
                set { relevance = value; }
                get { return relevance; }
            }

            public Entry Entry
            {
                get { return entry; }
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
            List<FoundAnswer> foundAnswers = new List<FoundAnswer>();

            // Find each entry that match any specified keyword. More matching keywords increase the answer relevence
            foreach (Entry entry in database)
            {
                //Question not already used?
                if(!entry.Used) {
                    FoundAnswer answer = new FoundAnswer(entry);

                    IEnumerable<string> matchingKeywords = entry.keywords.Intersect(keywords);

                    foreach (String s in matchingKeywords)
                    {
                        answer.IncreaseRelevance();
                    }

                    if (answer.Relevance > 0)
                    {
                        foundAnswers.Add(answer);
                    }
                }
            }

            // Sort the answer, putting the most relevant answer at the top
            foundAnswers.Sort();

            string theAnswer = "";

            if (foundAnswers.Count() > 0)
            {
                theAnswer = foundAnswers[0].Entry.answer;
                foundAnswers[0].Entry.UseQuestion();
            }

            return theAnswer;
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
