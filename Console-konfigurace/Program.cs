using System;



namespace Console_konfigurace
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " " + rnd.Next(1024) );
            }
        }
    }
}
