using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadCPFApp.BizRules;

namespace DadCPFApp.Model
{
    [Serializable]
    public class PermEmployee :Employee, VisitorEmployee
    {
        //private double _employerCPF = 0.0;
        //private double _employeeCPF = 0.0;

        public PermEmployee(string name, DateTime dob, long wage, string icno)
            : base(name, dob, wage, icno)
        {
        }
        public PermEmployee() :base("", DateTime.Now, 0L, "S9999991J")
        {
            this.SN = Services.GetLastCtr + 1;
        }

        #region VISITOR PATTERN
        public long GetMonthlyWage()
        {
            return this.ordinaryWage;
        }
        public void VisitElementRuleCPF_Employer(ElementRuleCPF_Employer f)
        {
            int age = GetMyAge();
            double employerCPF = 0.0;
            if (age <= 55)
            {
                employerCPF = this.GetMonthlyWage() * 0.17; //17%
                employerCPF = Math.Round((double)employerCPF, 2);
                
            }
            else if (age >55 && age <= 60)
            {
                employerCPF = this.GetMonthlyWage() * 0.13; //13%
                employerCPF = Math.Round((double)employerCPF, 2);
            }
            else if (age>60 && age <=65)
            {
                employerCPF = this.GetMonthlyWage() * 0.09; //9%
                employerCPF = Math.Round((double)employerCPF, 2);
            }
            else if (age>65)
            {
                employerCPF = this.GetMonthlyWage() * 0.075; //7.5%
                employerCPF = Math.Round((double)employerCPF, 2);
            }
            base._displayEmployerCPF = (float)employerCPF / 100;
            base._displayTotalCPF = base._displayEmployerCPF + base._displayEmployeeCPF;
            return; // not doing anything;
        }
        public void VisitElementRuleCPF_Employer(ElementRuleCPF_Employee f)
        {
            int age = GetMyAge();
            double employeeCPF = 0.0;
            if (age <= 55)
            {
                employeeCPF = this.GetMonthlyWage() * 0.20; //20%
                employeeCPF = Math.Round((double)employeeCPF, 2);

            }
            else if (age > 55 && age <= 60)
            {
                employeeCPF = this.GetMonthlyWage() * 0.13; //13%
                employeeCPF = Math.Round((double)employeeCPF, 2);
            }
            else if (age > 60 && age <= 65)
            {
                employeeCPF = this.GetMonthlyWage() * 0.075; //7.5%
                employeeCPF = Math.Round((double)employeeCPF, 2);
            }
            else if (age > 65)
            {
                employeeCPF = this.GetMonthlyWage() * 0.05; //5%
                employeeCPF = Math.Round((double)employeeCPF, 2);
            }
            base._displayEmployeeCPF= (float)employeeCPF/100; //2 decimal Places
            base._displayTotalCPF = base._displayEmployerCPF + base._displayEmployeeCPF;
            return; // not doing anything;
        }

        public int GetMyAge()
        {
            return (this.ZEROTIME + (DateTime.Now - this.DOB)).Year -1;
        }


        #endregion
    }
}
