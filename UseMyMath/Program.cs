using System;
using MyMath;

namespace UseMyMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Vec a = new Vec(1, -1.5);
            Vec b = a.Multiply(-1);
            Console.WriteLine(b);
            Vec c = a.Multiply(double.NaN);
            
        }
    }
}
