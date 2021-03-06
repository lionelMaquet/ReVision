﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    public class QAModel
    {

        
        public List<Proposition> FalsePropositions { get; set; }
        /// <summary>
        /// The question string
        /// </summary>
        public string Question { get; set; }
        public Proposition Answer { get; set; }

        
        public QAModel()
        {
            Question = "";
            Answer = new Proposition();
            FalsePropositions = new List<Proposition>();
        }

        public QAModel(string quest, Proposition trueAnswer, List<Proposition> falseAnswers)
        {
            
            Question = quest;
            Answer = trueAnswer;
            FalsePropositions = new List<Proposition>(falseAnswers);
            
        }
        

    }
}
