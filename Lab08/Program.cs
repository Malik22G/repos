namespace Lab08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BearEnum t = new BearEnum("C:\\Users\\malik\\Downloads\\input 4.txt");
            bool l = true;

            t.First();
            while (!t.end())
            {
                l = l & t.current().huntedBear;
                t.Next();
            }

            Console.WriteLine(l);
        }
    }
}