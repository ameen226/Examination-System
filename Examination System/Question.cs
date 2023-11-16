using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Question
    {

        #region Attributes And Properties
        private string _questionHeader;
        private string _questionBody;
        private double _mark;
        private Answer _rightAnswer;
        private Answer[] _answersArr;


        public Answer RightAnswer
        {
            get { return _rightAnswer; }
            set { _rightAnswer = value; }
        }

        public Answer[] AnswersArr
        {
            get { return _answersArr; }
            set { _answersArr = value; }
        }


        public string QuestionHeader
        {
            get { return _questionHeader; }
            set { _questionHeader = value; }
        }

        public string QuestionBody
        {
            get { return _questionBody; }
            set { _questionBody = value; }
        }

        public double Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        #endregion



        #region Constructors
        public Question(string questionHeader) : this(questionHeader, "", 0)
        {

        }

        public Question(string questionHeader, string questionBody, double mark)
        {
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            Mark = mark;

        }
        #endregion


        #region Methods
        public virtual void PromtingTheUser()
        {

            Console.Clear();

            bool flag;
            double mark;

            Console.WriteLine(QuestionHeader);
            Console.WriteLine("Please Enter The Body Of Question:");
            QuestionBody = Console.ReadLine();

            do
            {
                Console.WriteLine("Please Enter The Marks Of Question");
                flag = double.TryParse(Console.ReadLine(), out mark);
            } while (!flag);

            Mark = mark;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < AnswersArr.Length; i++)
            {
                if (i > 0) sb.Append("              ");
                sb.Append(AnswersArr[i]);
            }

            return $"{QuestionHeader}       Mark({Mark})\n" +
                $"{QuestionBody}\n{sb.ToString()}\n";
        } 
        #endregion


    }
}
