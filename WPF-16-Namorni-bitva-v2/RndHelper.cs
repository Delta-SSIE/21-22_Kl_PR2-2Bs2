using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_16_Namorni_bitva_v2
{
    public static class RndHelper
    {
        private static Random _instance;

        public static Random GetInstance()
        {
            if (_instance == null)
                _instance = new Random();

            return _instance;
        }
    }
}
