using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadCPFApp.Model;

namespace DadCPFApp.BizRules
{
    /// <summary>
    /// GoF Visitor Pattern
    /// </summary>
    public class VisitorObjStructure
    {
        List<ElementRule> elements = new List<ElementRule>();
        public VisitorObjStructure()
        {
            ElementRuleCPF_Employer e1 = new ElementRuleCPF_Employer();
            ElementRuleCPF_Employee e2 = new ElementRuleCPF_Employee();
            elements.Add(e2);
            elements.Add(e1);
        }
        
        public void Attach(ElementRule element)
        {
            elements.Add(element);
        }

        public void Detach(ElementRule element)
        {
            elements.Remove(element);
        }
        public void Calculate(VisitorEmployee emp)
        {
            foreach(ElementRule e in elements)
            {
                e.Accept(emp);
            }    
        }
        
    }
}
