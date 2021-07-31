using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.BizRules
{
    public abstract class ElementRule
    {
        public abstract void Accept(VisitorEmployee v);
        public abstract long GetAmount();
    }
}
