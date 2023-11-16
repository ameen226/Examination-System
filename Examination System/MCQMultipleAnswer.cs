using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQMultipleAnswer : Question
    {
        #region Fields And Properties
        private Answer[] _rightAnswersArr;
        private int _rightAnsCount;


        public int RightAnsCount
        {
            get { return _rightAnsCount; }
            set { _rightAnsCount = value; }
        }



        public Answer[] RightAnswersArr
        {
            get { return _rightAnswersArr; }
            set { _rightAnswersArr = value; }
        }
        #endregion

        #region Constructors
        public MCQMultipleAnswer() : base("Choose Multiple Answers Question")
        {
        }
        #endregion

        #region Methods
        public override void PromtingTheUser()
        {
            base.PromtingTheUser();

            bool flag;


            int choicesNum;

            do
            {
                Console.WriteLine("Enter The Number Of Choices (4) as Minimum And (6) as Maximum: ");
                flag = int.TryParse(Console.ReadLine(), out choicesNum);
            } while (!flag || choicesNum < 4 || choicesNum > 6);

            AnswersArr = new Answer[choicesNum];

            for (int i = 0; i < choicesNum; i++)
            {
                AnswersArr[i] = new Answer();
                Console.Write($"Please Enter The Choice Number {i + 1}: ");
                AnswersArr[i].AnswerText = Console.ReadLine();
                AnswersArr[i].AnswerId = i + 1;
            }

            int ansNum;

            do
            {
                Console.WriteLine($"Enter The Number Of Right Answers (2) as Minimum  And ({choicesNum - 1}) as Maximum");
                flag = int.TryParse(Console.ReadLine(), out ansNum);
            } while (!flag || ansNum < 2 || ansNum >= choicesNum);

            RightAnsCount = ansNum;

            RightAnswersArr = new Answer[ansNum];

            int rightAnsId;
            bool[] vis = new bool[choicesNum + 1];


            for (int i = 0; i < ansNum; i++)
            {
                do
                {
                    Console.WriteLine($"Enter The Right Answer Number {i + 1}:");
                    flag = int.TryParse(Console.ReadLine(), out rightAnsId);

                } while (!flag || rightAnsId < 1 || rightAnsId > choicesNum || vis[rightAnsId]);

                vis[rightAnsId] = true;

                RightAnswersArr[i] = (Answer)AnswersArr[rightAnsId - 1].Clone();

            }

        } 
        #endregion

    }
}
