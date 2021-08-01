using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    public class Company
    {
        protected string name;
        protected string uen;
        protected DateTime yearFounded;
        public Company()
        {
            this.name = "UNK";
            this.uen = "UNK";
            this.yearFounded = DateTime.Now;
        }
        public Company(string s, string uen)
        {
            this.name = s;
            this.uen = uen;
        }
        public string  Name { 
            get { return name; }
            set { name = value; }
        }
        
        public string UEN
        {
            get { return uen; }
            set { uen= value; }
        }

        public int Founded
        {
            get { return yearFounded.Year; }
            set {
                DateTime dt = new DateTime(value, 1, 1);
                this.yearFounded = dt;
            }
        }
    }
}
