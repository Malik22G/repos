using System;
using System.Linq;

class Program
{
    static void Main()
    {

        string firstLine = Console.ReadLine();
        var parts = firstLine.Split(' ');
        int N = int.Parse(parts[0]); 
        int M = int.Parse(parts[1]); 
        double L = double.Parse(parts[2]); 
        double maxAverage = 0;
        int warmestSettlement = -1; 


        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            int[] temperatures = line.Split(' ').Select(int.Parse).ToArray();
            double average = temperatures.Average();


            if (average <= L && average > maxAverage)
            {
                maxAverage = average;
                warmestSettlement = i + 1; 
            }
        }


        Console.WriteLine(warmestSettlement > 0 ? warmestSettlement.ToString() : "No settlement within limit");
    }
}
