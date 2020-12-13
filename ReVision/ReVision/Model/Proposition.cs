using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    public class Proposition
    {

        
        public string PropositionTitle { get; set; }
        public string Explanation { get; set; }

        public Proposition(string prop, string exp)
        {
            this.PropositionTitle = prop;
            this.Explanation = exp;
        }
        
        public Proposition()
        {
            PropositionTitle = "";
            Explanation = "";
        }
        
    }
}
