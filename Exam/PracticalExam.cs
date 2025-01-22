using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class PracticalExam : Exam
    {
         public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }


        public override void ShowExam()
        {
            int score = 0;
            int totalMarks = 0;

            Console.WriteLine("Practical Exam:");

            foreach (Question question in Questions)
            {
                question.DisplayQuestion(); 
                totalMarks += question.Mark;

                int userAnswer;
                while (true)
                {
                    Console.WriteLine("Enter your answer ID:");
                    if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer > 0 && userAnswer <= question.Answers.Length)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid answer. Please enter a valid option.");
                }

                if (question.Answers[userAnswer - 1].CompareTo(question.CorrectAnswer) == 0)
                {
                    score += question.Mark; 
                    Console.WriteLine("Correct Answer!");
                }
                else
                {
                    Console.WriteLine($"Incorrect Answer! The correct answer is:{question.CorrectAnswer.AnswerId}.{question.CorrectAnswer.AnswerText}");
                }

                Console.WriteLine($"Your score is: {score}/{totalMarks} ({(score * 100) / totalMarks}%)");
            }
        }
    }
}
