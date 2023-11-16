using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {


        #region Attributes And Properties
        private Answer[] _givenAnswersArr;




        public Answer[] GivenAnswersArr
        {
            get { return _givenAnswersArr; }
            set { _givenAnswersArr = value; }
        } 
        #endregion

        #region Constructors
        public FinalExam(int examTime, int questionNumbers) : base(examTime, questionNumbers)
        {
            QuestionsArr = new Question[questionNumbers + 1];
            GivenAnswersArr = new Answer[questionNumbers + 1];

        } 
        #endregion

        #region Methods
        public override void CreateQuestions()
        {
            for (int i = 1; i <= QuestionNumbers; i++)
            {
                Console.Clear();

                bool flag;
                int questionType;


                do
                {
                    Console.Write($"Please Choose The Type Of Question Number({i}) (1 for True OR False || 2 for MCQ) : ");
                    flag = int.TryParse(Console.ReadLine(), out questionType);

                } while (!flag || !(questionType == 1 || questionType == 2));

                if (questionType == 1)
                {
                    QuestionsArr[i] = new TrueOrFalse();
                    QuestionsArr[i].PromtingTheUser();
                }

                else
                {
                    QuestionsArr[i] = new MCQOneAnswer();
                    QuestionsArr[i].PromtingTheUser();

                }
            }
        }

        public override void StartExam()
        {
            bool flag;
            int ansLen;
            int ansId;

            for (int i = 1; i <= QuestionNumbers; i++)
            {
                if (i > 1) Console.WriteLine("*************************************");

                Console.WriteLine(QuestionsArr[i] + "\n-----------------------------");

                ansLen = QuestionsArr[i].AnswersArr.Length;

                do
                {
                    flag = int.TryParse(Console.ReadLine(), out ansId);
                } while (!flag || ansId < 1 || ansId > ansLen);

                GivenAnswersArr[i] = (Answer)QuestionsArr[i].AnswersArr[ansId - 1].Clone();

            }
        }

        public override void CalcGrade()
        {
            for (int i = 1; i <= QuestionNumbers; i++)
            {
                if (QuestionsArr[i].RightAnswer.Equals(GivenAnswersArr[i]))
                {
                    Grade += QuestionsArr[i].Mark;
                }
                TotalMarks += QuestionsArr[i].Mark;
            }
        }



        public override void ShowExam()
        {

            StartExam();

            Console.Clear();

            CalcGrade();
            Console.WriteLine("Your Answers:");
            for (int i = 1; i <= QuestionNumbers; i++)
            {
                Console.WriteLine($"Q{i})   {QuestionsArr[i].QuestionBody}: {GivenAnswersArr[i].AnswerText}");
            }
            Console.WriteLine($"Your Exam Grade is {Grade} from {TotalMarks}");

        } 
        #endregion


    }
}
