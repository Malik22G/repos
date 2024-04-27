using System.Runtime.InteropServices;

namespace C1prac
{
    internal class Program
    {
        struct Day
        {
            public int mint;
            public int maxt;
        }
        static void Main(string[] args)
        {
            int N;
            try
            {
                Console.WriteLine("Entre Number of Days");
                N = Convert.ToInt32(Console.ReadLine());
                while (N < 0)
                {
                    Console.WriteLine("N must be positive");
                    N = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch
            {
                Console.WriteLine("N must be a positive number So please entre a number not a string");
                N = Convert.ToInt32(Console.ReadLine());
            }

            Day[] Days = new Day[N];
            for(int i = 0; i < N; i++)
            {
                Console.WriteLine("Entre the minT and maxT for day {0} sperated by a space: ",i + 1);
                string [] line = Console.ReadLine().Split(" ");
                int mint, maxt;
                try
                {
                    mint = Convert.ToInt32(line[1]);
                    maxt = Convert.ToInt32(line[0]);
                }
                catch
                {
                    Console.WriteLine("Temp must be number not a string");
                    line = Console.ReadLine().Split(" ");
                    mint = Convert.ToInt32(line[1]);
                    maxt = Convert.ToInt32(line[0]);
                }
                if(maxt < mint)
                {
                    Console.WriteLine("Max temp must be greater than min temp");
                    i -= 1;
                    continue;
                }
                Days[i].mint = mint;
                Days[i].maxt = maxt;

            }

            int NCnt = 1;
            int MinDiff = Days[0].maxt - Days[0].mint;

            List<int> OutDays = new List<int>();
            OutDays.Add(1);

            for(int i =1; i < N; i++)
            {
                if (Days[i].maxt - Days[i].mint == MinDiff)
                {
                    NCnt += 1;
                    OutDays.Add(i + 1);
                }
                if(Days[i].maxt - Days[i].mint < MinDiff)
                {
                    NCnt = 1;
                    OutDays.Clear();
                    OutDays.Add(i + 1);
                    MinDiff = Days[i].maxt - Days[i].mint;
                }
            }

            Console.WriteLine("Number of days with minimum temp diffrence is: {0}", NCnt);
            Console.Write("These Days are:");
            foreach(int minDay in OutDays)
            {
                Console.Write("{0} ", minDay);
            }




        }
    }
}