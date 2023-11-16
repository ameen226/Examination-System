using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueOrFalse : Question
    {




        #region Constructors
        public TrueOrFalse() : base("True | False Question")
        {
            AnswersArr = new Answer[2];
            AnswersArr[0] = new Answer(1, "True");
            AnswersArr[1] = new Answer(2, "False");
        } 
        #endregion

        #region Methods
        public override void PromtingTheUser()
        {

            bool flag;
            int rightAnswerId;

            base.PromtingTheUser();



            do
            {
                Console.WriteLine("Please Enter The Right Answer Of Question (1 for True and 2 for False):");
                flag = int.TryParse(Console.ReadLine(), out rightAnswerId);
            } while (!flag || !(rightAnswerId == 1 || rightAnswerId == 2));

            RightAnswer = rightAnswerId == 1 ? new Answer(1, "True") : new Answer(2, "False");
        }


        #endregion

    }
}
