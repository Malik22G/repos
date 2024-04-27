using System;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Entre total number of movies: ");
        int numOfMovies = int.Parse(Console.ReadLine());
        while (numOfMovies < 1 || numOfMovies > 50)
        {
            Console.WriteLine("Number of movies mnust be betweeen 1 and 50 Enter again: ");
            numOfMovies = int.Parse(Console.ReadLine());
        }

        int[] MoviesDuration = new int[numOfMovies];
        string[] Movies = new string[numOfMovies];
        int totalDuration = 0;

        for (int i = 0; i < numOfMovies;)
        {
            string[] input = Console.ReadLine().Split(";");
            Movies[i] = input[0];
            MoviesDuration[i] = int.Parse(input[1]);

            if (Movies[i].Length < 1 || Movies[i].Length > 50)
            {
                Console.WriteLine("Movies name must be given and not exceed 50 character.");
                continue;
            }
            if (MoviesDuration[i] < 1 || MoviesDuration[i] > 300)
            {
                Console.WriteLine("Movies Duration must be  between 1 and 300");
                continue;
            }
            i++;

        }

        for (int i = 0; i < numOfMovies; i++)
        {
            for (int j = i + 1; j < numOfMovies - 1; j++)
            {
                if (MoviesDuration[i] < MoviesDuration[j])
                {
                    int numTmp = MoviesDuration[i];
                    MoviesDuration[i] = MoviesDuration[j];
                    MoviesDuration[j] = numTmp;

                    string strTmp = Movies[i];
                    Movies[i] = Movies[j];
                    Movies[j] = strTmp;
                }
            }
        }
        Console.WriteLine("Horror Movie Marathon Selection:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("- {0}", Movies[i]);
            totalDuration += MoviesDuration[i];

        }
        Console.WriteLine("Total Duration {0} minutes", totalDuration);
    }
}
