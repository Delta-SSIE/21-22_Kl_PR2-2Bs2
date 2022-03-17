using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dedicnost_010_Savec
{
    sealed class Kun : Savec
    {
        public Kun(string jmeno) : base(jmeno)
        {
        }

        public void Cvalej()
        {
            Console.WriteLine("Dupy dup");
        }

        public override void OzviSe()
        {
            if (zije)
                Console.WriteLine("Íííííhahá");
        }
    }

    //class Pony : Kun //nelze - kůň je uzavřený
    //{

    //}
}
