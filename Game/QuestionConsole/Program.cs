using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionConsole
{
    class Program
    {
        static Random vraaggenerator = new Random();

        static void Main(string[] args)
        {
            
            List<Question> question = new List<Question> {
                //dit is waar je vragen aanmaakt
                //parameter lijst als volgt
                //de vraag -> de mogelijke antwoorden - > het type vraag->
                //de index van de mogelijke antwoorden
                
                //multiple choice moeten 4 mogelijke antwoorden hebben
                //true and false moeten 2 mogelijke antwoorden hebben
                
                //multiple choice type vraag voorbeeld
                new Question("What is 1 + 1 ?", new string[] { "1", "2", "3", "4" }, Question.multipleChoice, 1),
                //true/false type vraag voorbeeld 
                new Question("2 + 2 does not equal 4.", new string[] { "true", "false" }, Question.trueAndFalse, 1),


                //andere voorbeelden
                new Question("What is 1 + 3 ?", new string[] { "1", "2", "3", "4" }, Question.multipleChoice, 3),
                new Question("The guy who sent you this solution is VERY COOL!", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 3 x 4 ?", new string[] { "9", "2", "12", "4" }, Question.multipleChoice, 2),
                new Question("The sky is blue.", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 5 + 5 ?", new string[] { "10", "2", "3", "4" }, Question.multipleChoice, 0),
                new Question("Water is wet.", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("Programming is fun.", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 3 x 5 ?", new string[] { "1", "15", "3", "4" }, Question.multipleChoice, 1)
            };


                Console.WriteLine("--------------------------------");
            int vraag = vraaggenerator.Next(question.Count);
                if (question[vraag].Ask())
                {
                    Console.WriteLine("Press any key to return to game");
                    Console.ReadKey();
                    Environment.Exit(2);
                }
                else
                {
                    Console.WriteLine("Press any key to return to game");
                    Console.ReadKey();
                    Environment.Exit(3);
                }
            
        }
    }
}
