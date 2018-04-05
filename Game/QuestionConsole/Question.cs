using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionConsole
{
        class Question
        {
            public string question;
            public string[] answers;
            public bool isCorrect;
            public string inputAnswer;
            private int correctIndex;
            private string questionType;
            public static string trueAndFalse = "TF";
            public static string multipleChoice = "MC";


            /// <summary>
            /// maak een object vraag. Geef een string voor een vraag, een array van strings voor mogelijke antwoorden, een vraag type en een index integer waarde voor het juiste antwoord in de array.
            /// </summary>
            /// <param name="q"></param>
            /// <param name="answers"></param>
            /// <param name="correctAnswer"></param>
            public Question(string q, string[] answersList, string typeOfQuestion, int correctAnswer)
            {
                question = q;
                questionType = typeOfQuestion;
            //als multiple choice dan 4 antwoorden
                if (questionType == multipleChoice)
                    answers = new string[4];
            //als true false dan 2 antwoorden
                else if (questionType == trueAndFalse)
                    answers = new string[2];

                for (int i = 0; i < answersList.Length; i++)
                {
                    this.answers[i] = answersList[i];
                }

                correctIndex = correctAnswer;
            }

        // hier worden de vragen op het beeld geprojecteerd
            public bool Ask()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(question);
                Console.ForegroundColor = ConsoleColor.White;
            // als multiple choice dan moet er input van de volgende mogelijkheden gegeven worden
                if (questionType == multipleChoice)
                {
                    Console.WriteLine("Input an answer from the following possibilities...");
                }
            // anders input moet true or false zijn
                else
                {
                    Console.WriteLine("Please input 'true' or 'false'... ");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < answers.Length; i++)
                {
                    Console.WriteLine(answers[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                inputAnswer = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

            //als het antwoord juist is dan
                if (inputAnswer == answers[correctIndex])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    isCorrect = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
            //als het antwoord fout is
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect, moving on!");
                    isCorrect = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }

                return isCorrect;
            }
        //dit is wat er op beeld komt
            public void PrintQuestion()
            {
                Console.WriteLine(question);
                if (questionType == multipleChoice)
                {
                    Console.WriteLine("Input an answer from the following possibilities...");
                }
                else
                {
                    Console.WriteLine("Please input 'true' or 'false'... ");
                }

                for (int i = 0; i < answers.Length; i++)
                {
                    Console.WriteLine(answers[i]);
                }
            }
        }
}

