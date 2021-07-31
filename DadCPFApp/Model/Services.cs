using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadCPFApp.BizRules;
using DadCPFApp.Model;

namespace DadCPFApp.Model
{
    public static class Services
    {
        private static ObservableCollection<Employee> emps = new ObservableCollection<Employee>();
        private static ObservableCollection<Company> cos = new ObservableCollection<Company>();
        private static VisitorObjStructure bizRule = new VisitorObjStructure();
        public static void Init()
        {
            
        }
        public static int GetLastCtr
        {
            get 
            {
                int lastCtr = 0;
                foreach (Employee e in emps)
                {
                    if (e.SN > lastCtr)
                        lastCtr = e.SN;
                }
                return lastCtr; 
            }
        }

        public static ObservableCollection<Employee> Employees
        {
            get
            {
                if (emps.Count==0)
                {
                    for (int i=8; i>0; --i)
                    {
                        PermEmployee p = new PermEmployee("Test", DateTime.Now, (long)100000, "S1818188A");
                        bizRule.Calculate(p);
                        p.SN = i+1;
                        emps.Add(p);
                    }
                }
                    
                return emps;
            }
        }

        public static ObservableCollection<Company> Companies
        {
            get
            {
                if (cos.Count==0)
                {
                    cos.Add(new CoGHL());
                    cos.Add(new CoGHLTrading());
                }
                return cos;
                
            }
        }


        public static void ReCalculate()
        {
            if (emps!=null)
            {
                foreach (Employee e in emps)
                {
                    PermEmployee p = e as PermEmployee;
                    if (p != null)
                        bizRule.Calculate(p);
                }
            }
        }
    }
}
