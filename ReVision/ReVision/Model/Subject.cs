using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class Subject
    {

        public int SubjectId { get; set; }
        /// <summary>
        /// Name of the subject (IE : History, math, ...)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// All questions and answers in the subject
        /// </summary>
        virtual public List<QAModel> Qas { get; set; }

        public Subject()
        {
        }



        public Subject(string name, List<QAModel> qas)
        {
            this.Name = name;
            this.Qas = qas;

        }


    }


}
