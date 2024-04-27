using System;
using System.Globalization;
     class Program
    {
        static void Main()
        {
        Console.WriteLine("Please enter number of movies limit Year and limit rating seperated by space: ");
        String[] input = Console.ReadLine().Split(' ');

        int dataLength = int.Parse(input[0]);
        while (dataLength < 1 || dataLength > 50)
        {
            Console.WriteLine("Number of movies must be between 0 and 50. Please enter the number again: ");
            dataLength = int.Parse(Console.ReadLine());
        }

        int limitYear = int.Parse(input[1]);

        while (limitYear<1932 || limitYear > 2022) {
            Console.WriteLine("Limit year must be between 1932 and 2022. Please enter the year again: ");
            limitYear = int.Parse(Console.ReadLine());
        }

        double limitRating = double.Parse(input[2]);

        while (limitRating < 0 || limitRating > 10)
        {
            Console.WriteLine("Number of movies must be between 0 and 50. Please enter the number again: ");
            limitRating = double.Parse(Console.ReadLine());
        }









    }
    }
