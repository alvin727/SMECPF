using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.BizRules
{
    public class ElementRuleCPF_Employer : ElementRule
    {
        public ElementRuleCPF_Employer() : base()
        {

        }

        public override void Accept(VisitorEmployee v)
        {
            v.VisitElementRuleCPF_Employer(this);
        }
        public override long GetAmount()
        {
            return 1000;
        }
    }
}
