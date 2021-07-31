using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    [Serializable]
    internal class CoGHL : Company
    {
        public CoGHL() : base("Guan Hup Lee Pte Ltd","TBA")
        {
            this.yearFounded = new DateTime(1975, 1, 1);
        }
    }
}
