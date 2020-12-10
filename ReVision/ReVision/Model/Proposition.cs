using System;
using System.Collections.Generic;
using System.Text;

namespace ReVision.Model
{
    class Proposition
    {
        private string _proposition;
        private string _explanation;

        public Proposition(string prop, string exp)
        {
            this.proposition = prop;
            this.explanation = exp;
        }

        internal string proposition
        {
            get
            {
                return _proposition;
            }

            set
            {
                _proposition = value;
            }
        }

        internal string explanation
        {
            get
            {
                return _explanation;
            }

            set
            {
                _explanation = value;
            }
        }
    }
}
