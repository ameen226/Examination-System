using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            subject.CreateExam();

            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                subject.SubjectExam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }


        }
    }
}
