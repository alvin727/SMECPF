using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadCPFApp.Model
{
    enum Race
    {
        Chinese=1,
        Indian,
        Eurasian
    }

    enum Agency
    {
        CDAC=1,
        SINDA,
        ECF
    }

    enum PaymenCode
    {
        CPF_Contribution=1,
        MBMF=2,
        SINDA=3,
        CDAC=4,
        EURASIAN_COMMUNITY_FUND=5,
        RESERVED=6,
        CPF_PENALTY_INTEREST=7,
        FOREIGN_WORKER_LEVY=8,
        FWL_PENALTY_INTEREST=9,
        COMMUNITY_CHEST=10,
        SKILL_DEVELOPMENT_FUND=11
    }
}
