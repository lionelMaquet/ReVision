using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class QAModel
    {
        private string _question;
        private Proposition _answer;
        internal List<Proposition> _falsePropositions = new List<Proposition>();

        public QAModel(string quest, Proposition trueAnswer, List<Proposition> falseAnswers)
        {
            question = quest;
            answer = trueAnswer;
            _falsePropositions = falseAnswers;
        }

        /// <summary>
        /// The question string
        /// </summary>
        internal string question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        internal Proposition answer
        {
            get
            {
                return _answer;
            }
            set {
                _answer = value;
            }
        }

        

    }
}
