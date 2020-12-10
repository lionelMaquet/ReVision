using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class QAModel
    {

        virtual public List<Proposition> falsePropositions { get; set; }
        /// <summary>
        /// The question string
        /// </summary>
        virtual public string question { get; set; }
        virtual public Proposition answer { get; set; }

        public QAModel(string quest, Proposition trueAnswer, List<Proposition> falseAnswers)
        {
            question = quest;
            answer = trueAnswer;
            falsePropositions = new List<Proposition>(falseAnswers);
        }

    }
}
