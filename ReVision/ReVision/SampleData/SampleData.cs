using ReVision.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision
{
    public class SampleData
    {
        
        internal List<QAModel> generalQAs;
        internal Subject general;
        internal List<Subject> allSubjects;
        public SampleData()
        {
            
            generalQAs = new List<QAModel>();
            


            
            generalQAs.Add(
                new QAModel(
                    "What is my age ? azebiazebaz eiazgebvjaz eazbeza eba abzjveiaz ezave azjev azieavzoeaz",
                    new Proposition("25", "oui"),
                    new List<Proposition>()
                    {
                        new Proposition("35", "non"),
                        new Proposition("12", "non"),
                        new Proposition("24", "non")
                    })
                );

            generalQAs.Add(
                new QAModel(
                    "Where do I live ?",
                    new Proposition("Juprelle", "oui"),
                    new List<Proposition>()
                    {
                        new Proposition("Verviers", "non"),
                        new Proposition("Herstal", "non"),
                        new Proposition("Bruxelles", "non")
                    })
                );

            generalQAs.Add(
                new QAModel(
                    "Qui est mon chien ?",
                    new Proposition("Shadow", "oui"),
                    new List<Proposition>()
                    {
                        new Proposition("Rex", "non"),
                        new Proposition("Fury", "non"),
                        new Proposition("Bibouche", "non")
                    })
                );


            // You create a Subject and feed it the QAs you created
            general = new Subject("general", generalQAs);

            allSubjects = new List<Subject>()
            {
                general
            };

            
        }




    }
}
