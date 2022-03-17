using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dedicnost_020_Obdelnik_a_ctverec
{
    class Ctverec : Obdelnik
    {
        public Ctverec(double strana) : base(strana, strana)
        {
        }

        public override string ToString()
        {
            return $"Čtverec o straně {StranaA}";
        }
    }
}
