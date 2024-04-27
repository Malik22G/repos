using System;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {
        int dayslength, compdays;
        do
        {
            string[] input = Console.ReadLine().Split(" ");
            dayslength = int.Parse(input[0]);
            compdays = int.Parse(input[1]);
        } while (dayslength < 1 || dayslength > 100 || compdays < 1 || compdays > 10);

        int[] metrics = new int[dayslength];
        for (int i = 0; i < dayslength; i++)
        {
            do
            {
                metrics[i] = int.Parse(Console.ReadLine());
            } while (metrics[i] < 1 || metrics[i] > 200);
        }
        int cnt = 0;
        for (int i = 0; i < dayslength; i++)
        {
            if (metrics[i] > 100)
            {
                cnt++;
            }
        }
        Console.WriteLine(cnt);
    }
}