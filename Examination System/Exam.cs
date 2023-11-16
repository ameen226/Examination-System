using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {

        #region Fields And Properties
        private int _examTime;
        private int _questionNumbers;
        private double _grade;
        private double _totalMarks;
        private Question[] _questionsArr;


        public Question[] QuestionsArr
        {
            get { return _questionsArr; }
            set { _questionsArr = value; }
        }

        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public double TotalMarks
        {
            get { return _totalMarks; }
            set { _totalMarks = value; }
        }

        public int ExamTime
        {
            get { return _examTime; }
            set { _examTime = value; }
        }

        public int QuestionNumbers
        {
            get { return _questionNumbers; }
            set { _questionNumbers = value; }
        } 
        #endregion

        #region Constructors
        public Exam() : this(default, 0)
        {

        }

        public Exam(int examTime, int questionNumbers)
        {
            ExamTime = examTime;
            QuestionNumbers = questionNumbers;
            Grade = 0;
            TotalMarks = 0;
        } 
        #endregion

        #region Abstract Methods
        public abstract void CreateQuestions();

        public abstract void StartExam();

        public abstract void ShowExam();

        public abstract void CalcGrade();

        #endregion
    }
}
