using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQOneAnswer : Question
    {



        #region Constructors
        public MCQOneAnswer() : base("Choose One Answer Question")
        {
            AnswersArr = new Answer[3];
            for (int i = 0; i < 3; i++) AnswersArr[i] = new Answer();
            RightAnswer = new Answer();
        } 
        #endregion

        #region Methods
        public override void PromtingTheUser()
        {
            bool flag;
            int rightAnswerId;

            base.PromtingTheUser();

            Console.WriteLine("The Choises Of Question:");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Please Enter The Choise Number {i}: ");
                AnswersArr[i - 1].AnswerText = Console.ReadLine();
                AnswersArr[i - 1].AnswerId = i;
            }

            do
            {
                Console.WriteLine("Please Specify The Right Choise of Question:");
                flag = int.TryParse(Console.ReadLine(), out rightAnswerId);
            } while (!flag || rightAnswerId < 1 || rightAnswerId > 3);

            RightAnswer = (Answer)AnswersArr[rightAnswerId - 1].Clone();

        } 
        #endregion

    }
}
