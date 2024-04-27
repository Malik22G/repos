namespace B2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); 
            int passengers = 0; 
            int noPassengerSections = 0; 

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int on = int.Parse(input[0]); 
                int off = int.Parse(input[1]); 

                passengers += on - off; 

                if (passengers == 0 && i < N - 1)
                {
                    noPassengerSections++;
                }
            }

            Console.WriteLine(noPassengerSections);
        }
    }
    }
