using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class Subject
    {
        public Subject(string name, List<QAModel> qas)
        {
            this.name = name;
            this.qas = qas;
        }

        /// <summary>
        /// Name of the subject (IE : History, math, ...)
        /// </summary>
        public string name;
        /// <summary>
        /// All questions and answers in the subject
        /// </summary>
        public List<QAModel> qas; 

    }

    
}
