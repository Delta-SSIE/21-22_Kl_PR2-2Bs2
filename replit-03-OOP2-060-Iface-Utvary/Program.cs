﻿using System;

namespace replit_03_OOP2_060_Iface_Utvary
{
    class Program
    {
        static void Main(string[] args)
        {
            Obdelnik o = new Obdelnik(10, 5);
            Ctverec c = new Ctverec(5);
            Popis(o);
            Popis(c);

        }

        static void Popis(IUtvar utvar)
        {
            Console.WriteLine($"{utvar.Nazev} má obvod {utvar.GetObvod()} a obsah {utvar.GetObsah()}");

        }
    }
}