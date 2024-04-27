namespace MidPrac3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q1 Q1solver = new Q1("C:\\Users\\malik\\source\\repos\\MidPrac3\\input.txt");
            Q1solver.Solve();

            Console.WriteLine(Q1solver.giveCount());


            MillerEnum t = new MillerEnum("C:\\Users\\malik\\source\\repos\\MidPrac3\\input.txt");
            List<int> output =new List<int>();
            
            t.first();
            while (!t.end())
            {
                if (t.current().isMillerWinner)
                {
                    output.Add(t.current().competitionNumber);
                }
                t.next();
            }

            Console.WriteLine(String.Join(",",output));

        }
    }
}