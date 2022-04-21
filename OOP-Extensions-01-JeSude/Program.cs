using System;
using System.Linq;

namespace OOP_Extensions_01_JeSude
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = 6;
            Console.WriteLine("číslo " + cislo +  (cislo.IsEven() ? " je sudé" : " je liché"));


            int[] cisla = { 5,6,7,6,5,6,5,4,5,6,7,5, 255};
            Console.WriteLine(cisla.Average());
            Console.WriteLine(cisla.ModAverage());
        }


    }

    static class Helper
    {
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        public static double ModAverage(this int[] numbers)
        {
            if (numbers.Length < 3)
            {
                throw new InvalidOperationException();
            }

            int min = numbers[0];
            int max = numbers[0];
            int sum = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                int num = numbers[i];
                
                sum += num;
                if (min > num)
                    min = num;

                if (max < num)
                    max = num;

            }

            sum -= min;
            sum -= max;

            return ((double)sum) / (numbers.Length - 2);
        }
    }

}
