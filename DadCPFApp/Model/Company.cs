using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    public abstract class Company
    {
        protected string name;
        protected string uen;
        protected DateTime yearFounded;
        public Company(string s, string uen)
        {
            this.name = s;
            this.uen = uen;
        }
        public string  Name { 
            get { return name; }
        }
        
        public string UEN
        {
            get { return uen; }
        }

        public int Founded
        {
            get { return yearFounded.Year; }
        }
    }
}
