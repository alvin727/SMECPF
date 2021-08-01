using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    public class Employee : ObservableObject
    {
        string name;
        string icNo;
        DateTime dob;
        protected long ordinaryWage;
        protected readonly DateTime ZEROTIME = new DateTime(1, 1, 1);
        float displayWage;
        protected float _displayEmployeeCPF;
        protected float _displayEmployerCPF;
        protected float _displayTotalCPF;
        int sn;

        public Employee()
        {
            this.name = "";
            this.dob = DateTime.Now;
            this.ordinaryWage = -1;
            this.displayWage = 0;
            this.icNo = "UNK";
        }

        public Employee(string s, DateTime dob, long wage, string ic) 
        {
            this.name = s;
            this.dob = dob;
            this.ordinaryWage = wage;
            this.displayWage = this.ordinaryWage / 100;
            this.icNo = ic;
        }

        public float TotalCPF
        {
            get { return this._displayTotalCPF; }
            set
            {
                if (value != this._displayTotalCPF)
                    this._displayTotalCPF = value;
                OnPropertyChanged("TotalCPF");
            }
        }

        public float EmployeeCPF 
        { 
            get { return this._displayEmployeeCPF; }
            set
            {
                if (value != this._displayEmployeeCPF)
                    this._displayEmployeeCPF = value;
                OnPropertyChanged("EmployeeCPF");
            }
        }

        public float EmployerCPF
        {
            get { return this._displayEmployerCPF; }
            set
            {
                if (value != this._displayEmployerCPF)
                    this._displayEmployerCPF = value;
                OnPropertyChanged("EmployerCPF");
            }
        }


        public int SN 
        {
            get { return sn; }
            set
            {
                if (value!=sn)
                {
                    sn = value;
                    OnPropertyChanged("SN");
                }
            }
        }


        public string ICNo 
        {
            get { return icNo; } 
            set
            {
                if (value.CompareTo(icNo)!=0)
                {
                    icNo = value;
                    OnPropertyChanged("ICNo");
                }
            }
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime DOB
        {
            get { return dob; }
            set
            {
                if (value != dob)
                {
                    dob = value;
                    OnPropertyChanged("DOB");
                }
            }
        }

        public float DisplayWage
        {
            get { return displayWage; }
            set
            {
                if (value!= displayWage)
                {
                    displayWage = value;
                    this.ordinaryWage = (long)value * 100;
                    OnPropertyChanged("DisplayWage");
                }
                Services.ReCalculate();
                OnPropertyChanged("EmployeeCPF");
                OnPropertyChanged("EmployerCPF");
            }
        }
        
    }
}
