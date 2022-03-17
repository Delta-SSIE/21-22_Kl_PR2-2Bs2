using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dedicnost_010_Savec
{
    abstract class Savec
    {
        public string Jmeno { get; private set; }
        protected bool zije;

        public Savec(string jmeno)
        {
            Jmeno = jmeno;
            zije = true;
        }

        public void Dychej ()
        {
            Console.WriteLine("Nádech - výdech");
        }
        public void SajMleko()
        {
            Console.WriteLine("Cucám, cucám, ...");
        }
        //public virtual void OzviSe()
        //{
        //    Console.WriteLine("Dělám zvuk");
        //}
        public abstract void OzviSe();
    }
}
