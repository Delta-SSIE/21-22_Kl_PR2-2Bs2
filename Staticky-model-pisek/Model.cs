using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticky_model_pisek
{
    class Model
    {
        public int PisekNaStavbe { get; set; }
        public int Cas { get; set; }
        private Kalendar kalendar;
        public int NejblizsiStartNakladani { get; set; }

        public void Naplanuj(int kdy, TypUdalosti co, Proces kdo)
        {
            kalendar.Pridej(new Udalost() { Co = co, Kdy = kdy, Kdo = kdo });
        }
        private void NactiKonfiguraci()
        {
            new Auto(100, 5, 5, 10, this, "Albert");
            new Auto(250, 15, 5, 20, this, "Bivoj");
            new Auto(40, 2, 2, 5, this, "Cvrček");
        }
        public void Simuluj()
        {
            int kolikPisku = 100;
            kalendar = new Kalendar();
            NactiKonfiguraci();

            while (PisekNaStavbe < kolikPisku)
            {
                Udalost u = kalendar.VyberPrvni();
                Console.WriteLine(u.Kdy + " : " + u.Kdo.Jmeno + " : " + u.Co);
                u.Kdo.Zpracuj(u.Kdy, u.Co);
            }
        }

    }
}
