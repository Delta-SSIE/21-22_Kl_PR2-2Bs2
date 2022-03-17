﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replit_03_OOP2_060_Iface_Utvary
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
