namespace MidPrac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q1 Q1solver = new Q1("C:\\Users\\malik\\source\\repos\\MidPrac\\input.txt");
            Q1solver.Solve();

            Console.WriteLine(Q1solver.isHighResults());

            EnumCompetition t = new EnumCompetition("C:\\Users\\malik\\source\\repos\\MidPrac\\input.txt");
            t.first();

            Stat elem = t.current();
            int min = t.current().points;

            t.next();
            while (!t.end())
            {
                if(t.current().points < min)
                {
                    elem = t.current();
                    min = t.current().points;
                }
                t.next();
            }

            Console.WriteLine(elem.points);
            
        }
    }
}