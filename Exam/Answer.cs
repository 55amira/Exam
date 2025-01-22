using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Answer : IComparable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public int CompareTo(object? obj)
        {
            Answer answer = (Answer)obj;
            if (this.AnswerId > answer.AnswerId) return -1;
            else if (this.AnswerId < answer.AnswerId) return 1;
            else return 0;
        }
    }
}
