using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.BizRules
{
    //Need to Inverse
    //Rule = Visitor ... Employee.. Element
    public interface VisitorEmployee
    {
        int GetMyAge();
        long GetMonthlyWage();
        void VisitElementRuleCPF_Employer(ElementRuleCPF_Employer f);
        void VisitElementRuleCPF_Employer(ElementRuleCPF_Employee f);
    }
}
