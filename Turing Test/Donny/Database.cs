﻿using System;
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
            List<FoundAnswer> foundAnswers = new List<FoundAnswer>();

            // Find each entry that match any specified keyword. More matching keywords increase the answer relevence
            foreach (Entry entry in database)
            {
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

            // Sort the answer, putting the most relevant answer at the top
            foundAnswers.Sort();

            string theAnswer = "";

            if (foundAnswers.Count() > 0)
            {
                theAnswer = foundAnswers[0].Entry.answer;
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
