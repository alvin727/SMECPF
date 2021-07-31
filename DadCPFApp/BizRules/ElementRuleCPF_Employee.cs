using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.BizRules
{
    public class ElementRuleCPF_Employee : ElementRule
    {
        long amt = 0;
        public ElementRuleCPF_Employee()
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
