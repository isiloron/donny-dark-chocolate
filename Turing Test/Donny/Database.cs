using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donny
{
    class Database
    {
        class Entry
        {
            string[] keywords;
            string answer;

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
