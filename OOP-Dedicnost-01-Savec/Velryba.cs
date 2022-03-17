using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dedicnost_010_Savec
{
    class Velryba : Savec
    {
        public int PocetPloutvi { get; private set; }
        public Velryba(string jmeno, int pocetPloutvi) : base(jmeno)
        {
            PocetPloutvi = pocetPloutvi;
        }

        public override void OzviSe()
        {
            Console.WriteLine("Pýsk pýsk");
        }

        public void PlacniPloutvi()
        {
            Console.WriteLine("Šplouch");
        }
    }
}
