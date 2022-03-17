using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dedicnost_020_Obdelnik_a_ctverec
{
    class Obdelnik
    {
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }

        public Obdelnik(double stranaA, double stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }

        public double GetObvod()
        {
            return 2 * (StranaA + StranaB);
        }
        public double GetObsah()
        {
            return StranaA * StranaB;
        }
        public override string ToString()
        {
            return $"Obdélník {StranaA} x {StranaB}.";
        }
    }
}
