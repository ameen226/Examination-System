using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {

        #region Fields And Properties

        private int _subjectId;
        private string _subjectName;
        private Exam _subjectExam;

        public int SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }

        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        public Exam SubjectExam
        {
            get { return _subjectExam; }
            set { _subjectExam = value; }
        } 
        #endregion

        #region Constructors
        public Subject() : this(0, "", default)
        {

        }

        public Subject(int subjectId, string subjectName) : this(subjectId, subjectName, default)
        {

        }

        public Subject(int subjectId, string subjectName, Exam subjectExam)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            SubjectExam = subjectExam;
        } 
        #endregion

        #region Methods
        public void CreateExam()
        {

            int examType;
            bool flag;

            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create ( 1 for Practical and 2 for Final): ");
                flag = int.TryParse(Console.ReadLine(), out examType);
            }
            while (!flag || !(examType == 1 || examType == 2));

            int examDuration;

            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes: ");
                flag = int.TryParse(Console.ReadLine(), out examDuration);
            }
            while (!flag);

            int questionNumbers;

            do
            {
                Console.Write("Please Enter The Number Of Questions You Wanted To Create: ");
                flag = int.TryParse(Console.ReadLine(), out questionNumbers);
            }
            while (!flag);

            if (examType == 2)
            {
                SubjectExam = new FinalExam(examDuration, questionNumbers);
                SubjectExam.CreateQuestions();
            }
            else
            {
                SubjectExam = new PracticalExam(examDuration, questionNumbers);
                SubjectExam.CreateQuestions();
            }


        } 
        #endregion


    }
}
