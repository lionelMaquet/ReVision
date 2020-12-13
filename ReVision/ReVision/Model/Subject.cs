using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    public class Subject
    {

        /// <summary>
        /// Name of the subject (IE : History, math, ...)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// All questions and answers in the subject
        /// </summary>
        public List<QAModel> Qas { get; set; }

        
        public Subject()
        {
            Name = "";
            Qas = new List<QAModel>();
        }


        public Subject(string name, List<QAModel> qas)
        {
            this.Name = name;
            this.Qas = qas;

        }
        

    }


}
