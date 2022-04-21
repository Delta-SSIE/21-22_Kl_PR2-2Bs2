using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Staticky_model_pisek
{
    class Kalendar
    {
        List<Udalost> seznam;

        public int Pocet => seznam.Count;

        public Kalendar()
        {
            seznam = new List<Udalost>();
        }

        public void Pridej(Udalost u)
        {
            for (int i = 0; i < seznam.Count; i++)
            {
                if (u.Kdy < seznam[i].Kdy)
                {
                    seznam.Insert(i, u);
                    return;
                }
            }
            seznam.Add(u);
        }
        
        public Udalost VyberPrvni()
        {
            //Debug.Assert(seznam.Count < 1, "Prázdný kalendář");

            Udalost u = seznam[0];
            seznam.RemoveAt(0);
            
            return u;
        }
    }
}
