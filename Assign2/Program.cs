using System;

namespace Atmosphere_nps
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the path to file: ");
            string file = Console.ReadLine();

            Atmosphere atmosphere = new Atmosphere(file);
            atmosphere.LoadDataSimulate();
        }
    }

}