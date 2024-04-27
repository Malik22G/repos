namespace PracticeMidTerm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q1 Q1solver = new Q1("C:\\Users\\malik\\Desktop\\input.txt");

            Q1solver.solve();
            Console.WriteLine(Q1solver.giveCount());

            SemesterEnum t = new SemesterEnum("C:\\Users\\malik\\Desktop\\input.txt");

            t.first();
            int min = t.current().hours;
            semHoursData elem = t.current();

            t.next();
            while (!t.end())
            {
                if (t.current().hours < min)
                {
                    min = t.current().hours;
                    elem = t.current();
                }
                t.next();
            }
            Console.WriteLine(elem.sem);
        }
    }
}