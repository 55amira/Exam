using System;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Subject ID :");
                int subjectId;

                while (!int.TryParse(Console.ReadLine(), out subjectId))
                {
                    Console.WriteLine("Invalid input. Please enter a vaild ID:");
                }

                Console.WriteLine("Enter Subject Name:");

                string subjectName;

                while (true)
                {
                    subjectName = Console.ReadLine();

                    if (string.IsNullOrEmpty(subjectName))
                    {
                        Console.WriteLine("Subject name cannot be empty. Please enter a valid name:");
                    }
                    else
                    {
                        break;
                    }
                }

                Subject subject = new Subject(subjectId, subjectName);

                Console.WriteLine("Choose Exam Type (1 for Final, 2 for Practical):");

                int examType;

                while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2))
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Final or 2 for Practical:");
                }

                Console.WriteLine("Enter exam time (in minutes):");

                int examTime;

                while (!int.TryParse(Console.ReadLine(), out examTime) || examTime <= 0)
                {
                    Console.WriteLine("Invalid time. Please enter a positive number:");
                }

                Console.WriteLine("Enter Number of Questions:");

                int numberOfQuestions;

                while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid number. Please enter a positive number:");
                }

                Exam exam;
               
                if (examType == 1)
                {
                    exam= new FinalExam(examTime, numberOfQuestions);
                } 
                else 
                {
                    exam= new PracticalExam(examTime, numberOfQuestions);
                }

                for(int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine($"Creating Question {i + 1}...");

                    int questionType =2;

                    if (exam is FinalExam)
                    {
                        Console.WriteLine("Choose Question Type (1 for True/False, 2 for MCQ):");
                        while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True/False or 2 for MCQ:");
                        }
                    }

                    Console.WriteLine("Enter Question Body:");

                    string body;

                    while (true)
                    {
                        body = Console.ReadLine();

                        if (string.IsNullOrEmpty(body))
                        {
                            Console.WriteLine("the body cannot be empty. Please enter body:");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Enter Question Mark:");

                    int mark;

                    while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                    {
                        Console.WriteLine("Invalid mark. Please enter a positive number:");
                    }

                    if(questionType== 1)
                    {
                        TrueFalseQuestion tfQuestion = new TrueFalseQuestion(body, mark, i + 1);

                        
                        tfQuestion.Answers = new Answer[2]
                        {
                             new Answer(1, "True"),
                             new Answer(2, "False")
                        };

                        Console.WriteLine("Enter Correct Answer (1 for True, 2 for False):");

                        int answerId;

                        while (!int.TryParse(Console.ReadLine(), out answerId) || (answerId != 1 && answerId != 2))
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False:");
                        }

                        tfQuestion.CorrectAnswer = tfQuestion.Answers[answerId - 1];

                        exam.Questions[i] = tfQuestion;
                    }
                    else 
                    {
                        MCQQuestion mcqQuestion = new MCQQuestion(body, mark, i + 1);

                        Console.WriteLine("Enter Number of Answers :");

                        int answerCount;

                        while (!int.TryParse(Console.ReadLine(), out answerCount) || answerCount < 2)
                        {
                            Console.WriteLine("Invalid input. Please enter a number greater than or equal to 2:");
                        }

                        mcqQuestion.Answers = new Answer[answerCount];

                        for (int j = 0; j < answerCount; j++)
                        {
                            Console.WriteLine($"Enter Answer {j + 1} :");
                            while (true)
                            {
                                string answerText = Console.ReadLine();

                                if (string.IsNullOrEmpty(subjectName))
                                {
                                    Console.WriteLine("Answer body cannot be empty. Please enter answer:");
                                }
                                else
                                {
                                    mcqQuestion.Answers[j] = new Answer(j + 1, answerText);
                                    break;
                                }
                            }
                            
                            
                        }

                        Console.WriteLine("Enter Correct Answer ID:");

                        int correctAnswer;

                        while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > answerCount)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid ID:");
                        }

                        mcqQuestion.CorrectAnswer = mcqQuestion.Answers[correctAnswer - 1];

                        exam.Questions[i] = mcqQuestion;

                    }

                    Console.WriteLine($"Question {i + 1} added successfully.");

                }

                subject.CreateExam(exam);

                Console.WriteLine("Exam Created Successfully. Do you want start the Exam (1 for Yes, 2 for No):");

                int startExam;

                while (!int.TryParse(Console.ReadLine(), out startExam) || (startExam != 1 && startExam != 2))
                {
                    Console.WriteLine("Invalid input. Please enter (1 for Yes, 2 for No):");
                }
                
                if (startExam == 1)
                {
                    subject.SubjectExam.ShowExam();
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
