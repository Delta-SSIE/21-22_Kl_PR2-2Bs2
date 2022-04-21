using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticky_model_pisek
{
    abstract class Proces
    {
        public string Jmeno;
        public abstract void Zpracuj(int cas, TypUdalosti co);
    }
}
