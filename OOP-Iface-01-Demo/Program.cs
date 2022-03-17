using System;

namespace OOP_Iface_01_Demo
{
    interface IPojizdny
    {
        public int PocetKol { get; }
    }

    enum TypMotoru { Benzin, Diesel, Vodik, Elektromotor }
    interface IMotorovy
    {
        public void Napln();
        public double VykonMotoru { get; }
        public TypMotoru Motor { get; }
    }
    class Kolecko : IPojizdny
    {
        public int PocetKol => 1;

        //public int PocetKol
        //{
        //    get
        //    {
        //        return 1;
        //    }
        //}
    }

    class Brusle : IPojizdny
    {
        public int PocetKol { get; private set; }
        public Brusle(int pocetKol)
        {
            PocetKol = pocetKol;
        }
    }

    class Tramvaj : IPojizdny, IMotorovy
    {
        private double kapacita;
        private double stav;
        public int PocetKol => 8;

        public double VykonMotoru => 230;

        public TypMotoru Motor => TypMotoru.Elektromotor;

        public void Napln()
        {
            stav = kapacita;
        }

        public void Nastup(int kolik)
        {
            //uloz lidi
        }
        publiv void Vystup(int kolik)
        {
            //vyhod lidi
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Kolecko k = new Kolecko();
            Brusle b1 = new Brusle(4);
            Brusle b2 = new Brusle(2);

            IPojizdny brusleJinak = b1;
            Console.WriteLine(b1.PocetKol);

            IPojizdny[] jezditka = new IPojizdny[3];
            jezditka[0] = k;
            jezditka[1] = b1;
            jezditka[2] = b2;

            foreach (IPojizdny vec in jezditka)
            {
                Console.WriteLine(vec.GetType() + ":" + vec.PocetKol);
            }

            Tramvaj t = new Tramvaj();
            t.Nastup(8); //je přístupné

            IPojizdny t1 = t;
            //lze vidět jen počet kol, zbytek nemá Iface v sobě

            IMotorovy t2 = t;
            //t2 ukazuje jen motor, napln apod, ale nelze nastupovat
            
        }
    }
}
