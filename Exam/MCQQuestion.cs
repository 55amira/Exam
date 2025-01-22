using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string body, int mark, int questionNumber) : base(body, mark, questionNumber) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine("MCQ Question");
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
    }

}
