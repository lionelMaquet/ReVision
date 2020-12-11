using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class QAModel
    {

        virtual public int QAModelId { get; set; }
        virtual public List<Proposition> FalsePropositions { get; set; }
        /// <summary>
        /// The question string
        /// </summary>
        virtual public string Question { get; set; }
        virtual public Proposition Answer { get; set; }

        public QAModel()
        {

        }

        public QAModel(string quest, Proposition trueAnswer, List<Proposition> falseAnswers)
        {
            
            Question = quest;
            Answer = trueAnswer;
            FalsePropositions = new List<Proposition>(falseAnswers);
            
        }

    }
}
