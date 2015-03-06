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
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string[] words = question.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] keywords = words.Where(word => database.IdentifyKeyword(word)).ToArray<string>();
            keywords = keywords.Distinct().ToArray<string>();
            return keywords;
        }

    }
}
