using System;

namespace OOP_Dedicnost_010_Savec
{
    class Program
    {
        static void Main(string[] args)
        {
            Kun kobyla = new Kun("Ferda");
            kobyla.Dychej();
            kobyla.Cvalej();

            Velryba mobyDick = new Velryba("Moby Dick", 4);
            mobyDick.Dychej();
            mobyDick.SajMleko();
            mobyDick.PlacniPloutvi();

            //kobyla.PlacniPloutvi(); //nezkompiluje se, kobyla metodu nemá

            Savec zvire = new Kun("Trudy");
            Kun jinyKun = (Kun)zvire;
            jinyKun.Cvalej();

            //Velryba divnaVelryba = (Velryba)zvire; zkompiluje se, ale chyba běhu
            //divnaVelryba.PlacniPloutvi();

            //zvire.OzviSe();
            //kobyla.OzviSe();

            Savec[] zvirata = new Savec[3];
            zvirata[0] = kobyla;
            zvirata[1] = mobyDick;
            zvirata[2] = jinyKun;

            foreach (Savec  savec in zvirata)
            {
                savec.OzviSe();
            }

            //Savec savecObecny = new Savec("Karel"); //nejde, savec je abstraktní
        }
    }
}
