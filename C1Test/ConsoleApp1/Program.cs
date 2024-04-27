using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter number of movies limit Year and limit rating seperated by space: ");
        string[] input = Console.ReadLine().Split(' ');

        int dataLength = int.Parse(input[0]);
        while (dataLength < 1 || dataLength > 50)
        {
            Console.WriteLine("Number of movies must be between 0 and 50. Please enter the number again: ");
            dataLength = int.Parse(Console.ReadLine());
        }

        int limitYear = int.Parse(input[1]);

        while (limitYear < 1932 || limitYear > 2022)
        {
            Console.WriteLine("Limit year must be between 1932 and 2022. Please enter the year again: ");
            limitYear = int.Parse(Console.ReadLine());
        }

        double limitRating = double.Parse(input[2]);

        while (limitRating < 0 || limitRating > 10)
        {
            Console.WriteLine("Limit rating must be between 0 and 10 ");
            limitRating = double.Parse(Console.ReadLine());
        }

        int[] year = new int[dataLength];
        double[] rating = new double[dataLength];
        string[] title = new string[dataLength];

        for (int i = 0; i < dataLength; i++)
        {
            string[] data = Console.ReadLine().Split(';');

            year[i] = int.Parse(data[0]);

            while (year[i] < 1932 || year[i] > 2022)
            {

                Console.WriteLine("Year must be between 1932 and 2022 on line {0}", i + 1);
                year[i] = int.Parse(Console.ReadLine());
            }

            rating[i] = double.Parse(data[1]);
            while (rating[i] < 0 || rating[i] > 10)
            {

                Console.WriteLine("rating must be between 0 and 10 on line {0}", i + 1);
                rating[i] = double.Parse(Console.ReadLine());
            }

            title[i] = data[2];
            while (title[i].Length < 1 || title[i].Length > 50)
            {

                Console.WriteLine("Tiltle must be of length 1 to 50 on line {0}", i + 1);
                title[i] = Console.ReadLine();
            }
        }

       






    }
}
