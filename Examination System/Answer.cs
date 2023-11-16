using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Answer : ICloneable
    {

        #region Fields And Properties
        private int _answerId;
        private string _answerText;

        public int AnswerId
        {
            get { return _answerId; }
            set { _answerId = value; }
        }

        public string AnswerText
        {
            get { return _answerText; }
            set { _answerText = value; }
        } 
        #endregion

        #region Constructor
        public Answer() : this(0, "")
        {

        }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        } 
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{AnswerId}.  {AnswerText}";
        }

        public override bool Equals(object? obj)
        {
            Answer otherAns = obj as Answer;
            if (obj is null) return false;

            return AnswerId.Equals(otherAns.AnswerId) && AnswerText.Equals(otherAns.AnswerText);
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        } 
        #endregion

    }
}
