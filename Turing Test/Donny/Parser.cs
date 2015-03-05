using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donny
{
    static class Parser
    {

        static public string[] ParseQuestion(string question, Database database)
        {
            string[] words = question.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            string[] keywords = (string[])words.Where(word => database.IdentifyKeyword(word));
            keywords = (string[])keywords.Distinct();
            return keywords;
        }

    }
}
