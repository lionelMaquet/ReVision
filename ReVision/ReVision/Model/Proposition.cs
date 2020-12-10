using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class Proposition
    {

        public int PropositionId { get; set; }
        public string proposition { get; set; }
        public string explanation { get; set; }

        public Proposition(string prop, string exp)
        {
            this.proposition = prop;
            this.explanation = exp;
        }

        
        
    }
}
