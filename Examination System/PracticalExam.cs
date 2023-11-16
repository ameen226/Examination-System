using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {

        #region Attributes And Methods
        private Answer[][] _givenAnswersArr;

        public Answer[][] GivenAnswersArr
        {
            get { return _givenAnswersArr; }
            set { _givenAnswersArr = value; }
        }
        #endregion

        #region Constructors
        public PracticalExam(int examTime, int questionNumbers) : base(examTime, questionNumbers)
        {
            QuestionsArr = new MCQMultipleAnswer[questionNumbers + 1];
            GivenAnswersArr = new Answer[questionNumbers + 1][];
        }
        #endregion



        #region Methods
        public override void CreateQuestions()
        {
            Console.Clear();
            for (int i = 0; i < QuestionNumbers; i++)
            {
                QuestionsArr[i + 1] = new MCQMultipleAnswer();
                QuestionsArr[i + 1].PromtingTheUser();

            }
        }

        public override void StartExam()
        {
            string[] pos = { "", "First", "Second", "Third", "Forth", "Fifth" };
            bool flag;
            int ansNum;

            MCQMultipleAnswer question;

            for (int i = 1; i <= QuestionNumbers; i++)
            {
                question = (MCQMultipleAnswer)QuestionsArr[i];
                if (i > 1) Console.WriteLine("*************************************");

                Console.WriteLine(QuestionsArr[i] + "\n-----------------------------");

                GivenAnswersArr[i] = new Answer[question.RightAnsCount + 1];

                bool[] vis = new bool[question.AnswersArr.Length + 1];

                for (int j = 1; j <= question.RightAnsCount; j++)
                {


                    do
                    {
                        Console.Write($"Enter Your {pos[j]} Answer : ");
                        flag = int.TryParse(Console.ReadLine(), out ansNum);
                    } while (!flag || ansNum < 1 || ansNum > question.AnswersArr.Length || vis[ansNum]);

                    vis[ansNum] = true;

                    GivenAnswersArr[i][j] = (Answer)question.AnswersArr[ansNum - 1].Clone();
                }
            }
        }


        public override void CalcGrade()
        {
            MCQMultipleAnswer question;
            Answer[] answerArr;
            Answer givenAns;
            Answer rightAns;

            for (int i = 1; i <= QuestionNumbers; i++)
            {
                question = (MCQMultipleAnswer)QuestionsArr[i];
                answerArr = question.RightAnswersArr;



                for (int j = 1; j < GivenAnswersArr[i].Length; j++)
                {
                    givenAns = GivenAnswersArr[i][j];
                    for (int k = 1; k < answerArr.Length; k++)
                    {
                        rightAns = answerArr[k];
                        if (givenAns.Equals(rightAns))
                        {
                            Grade += (question.Mark / question.RightAnsCount);
                            break;
                        }
                    }
                }
                TotalMarks += question.Mark;
            }
        }

        public override void ShowExam()
        {
            StartExam();

            Console.Clear();

            CalcGrade();
            Console.WriteLine("Your Answers:\n");


            MCQMultipleAnswer question;

            for (int i = 1; i <= QuestionNumbers; i++)
            {

                question = (MCQMultipleAnswer)QuestionsArr[i];


                StringBuilder givenAns = new StringBuilder();
                StringBuilder rightAns = new StringBuilder();

                for (int j = 1; j < GivenAnswersArr[i].Length; j++)
                {
                    if (j > 1)
                    {
                        givenAns.Append(", ");
                        rightAns.Append(", ");
                    }
                    givenAns.Append(GivenAnswersArr[i][j].AnswerText);
                    rightAns.Append(question.RightAnswersArr[j - 1].AnswerText);
                }

                Console.WriteLine($"Q{i})   {QuestionsArr[i].QuestionBody}: {givenAns}\n");

                Console.WriteLine($"Right Answers: {rightAns}\n");
            }
            Console.WriteLine($"\n\nYour Exam Grade is {Grade} from {TotalMarks}");


        } 
        #endregion



    }
}
