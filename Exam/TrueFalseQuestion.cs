using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int mark, int questionNumber) : base(body, mark, questionNumber) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine("[True|False] Question");
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            Console.WriteLine("1. True\n2. False");
        }
    }
    
}
