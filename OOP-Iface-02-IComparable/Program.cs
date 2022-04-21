using System;

namespace OOP_Iface_02_IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            Zamestanec[] lidi = new Zamestanec[]
            {
                new Zamestanec() {Jmeno = "Karel", Vyplata = 25000},
                new Zamestanec() {Jmeno = "Eman" , Vyplata = 27000},
                new Zamestanec() {Jmeno = "Alois", Vyplata = 22000},
                new Zamestanec() {Jmeno = "Hugo" , Vyplata = 27000},
                new Zamestanec() {Jmeno = "Jarda", Vyplata = 33000},
                new Zamestanec() {Jmeno = "Miloš", Vyplata = 24000},
            };

            Array.Sort(lidi);

            foreach (Zamestanec z in lidi)
            {
                Console.WriteLine($"{z.Jmeno} ({z.Vyplata})");
                
            }
        }

        class Zamestanec : IComparable
        {
            public int Vyplata { get; set; }
            public string Jmeno { get; set; }

            public int CompareTo(object obj)
            {
                Zamestanec jiny = obj as Zamestanec;
                if (jiny == null)
                    return -1; // divné věci nechám na konec

                if (jiny.Vyplata < this.Vyplata)
                    return +1; // cizí je dřív
                else if (jiny.Vyplata == this.Vyplata)
                    return 0;
                //return this.Jmeno.CompareTo(jiny.Jmeno);
                else
                    return -1;

            }

        }
    }
}
