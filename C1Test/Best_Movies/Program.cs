using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter number of movies limit Year and limit rating seperated by space: ");
        int dataLength, limitYear;
        double limitRating;
        do
        {
            string[] input = Console.ReadLine().Split(' ');
            dataLength = int.Parse(input[0]);
            limitYear = int.Parse(input[1]);
            limitRating = double.Parse(input[2]);
        } while (dataLength < 1 || dataLength > 50 || limitYear < 1932 || limitYear > 2022 || limitRating < 0 || limitRating > 10);
        
        
        int[] year = new int[dataLength];
        double[] rating = new double[dataLength];
        string[] title = new string[dataLength];

        for(int i = 0; i < dataLength;)
        {
            Console.WriteLine("Entre Data for a movie: ");
            string[] data = Console.ReadLine().Split(';');

            year[i] = int.Parse(data[0]);

            rating[i] = double.Parse(data[1]);
            
            title[i] = data[2];
            
            if (year[i] >= 1932 && year[i] <= 2022 && rating[i] >= 0 && rating[i] <= 10 && title[i].Length >= 1 && title[i].Length <= 50)
            {
                i++;
            }
        }

        double maxRatedVal = 0;
        int maxRatedInd = 0;

        for(int i = 0; i < dataLength; i++)
        {
            if (year[i] == limitYear && rating[i] > maxRatedVal)
            {
                maxRatedVal = rating[i];
                maxRatedInd = i;
            }
        }
        String filmTilteForMaxVal = title[maxRatedInd];

        Console.WriteLine("#1 \n{0}",filmTilteForMaxVal);

        string filmTitleAll = "";

        for (int i = 0; i < dataLength; i++)
        {
            if (rating[i] == limitRating)
            {
                filmTitleAll = filmTitleAll + title[i] + "\n";
            }
        }
        Console.WriteLine("#2 \n{0}",filmTitleAll);
    }
}
