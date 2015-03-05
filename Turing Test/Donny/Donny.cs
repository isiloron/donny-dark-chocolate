using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donny
{
    class Donny
    {
        Database database;

        public Donny()
        {
            database = new Database();
        }

        public void MainLoop()
        {
            //greet user
            Console.WriteLine("Hej!");

            //answer questions
            while(true)
            {
                //get question
                string question = Console.ReadLine();

                //parse question
                string[] keywords = Parser.ParseQuestion(question, database);
                
                //query database
                string answer = database.GetAnswer(keywords);

                //respond
                Console.WriteLine(answer);
            }
        }

    }
}
