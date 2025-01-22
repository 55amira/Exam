using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Question(string body, int mark, int questionNumber)
        {
            Header = $"Question {questionNumber}";
            Body = body;
            Mark = mark;
            Answers = new Answer[0];
        }

        public abstract void DisplayQuestion();
    }
}