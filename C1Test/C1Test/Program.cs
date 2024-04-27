namespace C1Test
{
    internal class Program
    {
        struct Day
        {
            public int maxt;
            public int mint;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Entre Number of days: ");
            int N = Convert.ToInt32(Console.ReadLine());

            if (N < 0)
            {
                Console.WriteLine("Entre a valid number positive number: ");
                N = Convert.ToInt32(Console.ReadLine());
            }

            Day[] Days = new Day[N];
            int NCnt = 1;

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Enter Max tempreature and Min Tempreature spearated by a space for Day {0}", i+1);
                string[] line = Console.ReadLine().Split(' ');
                try
                {
                    if (Convert.ToInt32(line[0]) >= Convert.ToInt32(line[1]))
                    {
                        Days[i].maxt = Convert.ToInt32(line[0]);
                        Days[i].mint = Convert.ToInt32(line[1]);
                    }
                    else
                    {
                        Console.WriteLine("Enter maxT first and minT second.");
                        i -= 1;
                        continue;
                    }
                }
                catch
                {

                    Console.WriteLine("Enter valid numbers");
                    i -= 1;
                    continue;
                }
                }

        int MaxDif = Days[0].maxt - Days[0].mint;
            List<int> OutDays = new List<int>();

            OutDays.Add(1);

            for(int i = 1; i < N; i++)
            {
                if (Days[i].maxt - Days[i].mint == MaxDif)
                {
                    NCnt++;
                    OutDays.Add(i+1);
                }
                if(Days[i].maxt - Days[i].mint > MaxDif)
                {
                    NCnt = 1;
                    OutDays.Clear();
                    OutDays.Add(i+1);
                    MaxDif = Days[i].maxt - Days[i].mint;
                }
            }


            Console.WriteLine("Number of Days with Maximum temp diffrence of {1} are: {0}", NCnt,MaxDif);
            Console.Write("These Days are: ");
            foreach(int day in OutDays)
            {
                Console.Write("{0} ", day);
            }

        }
    } 
}
            
      
  