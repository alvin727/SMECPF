using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    [Serializable]
    internal class CoGHLTrading : Company
    {
        public CoGHLTrading()
            :base ("Guan Hup Lee Trading", "TBA")
        {
            this.yearFounded = new DateTime(2016, 1, 1);
        }
    }
}
