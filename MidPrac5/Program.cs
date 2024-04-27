namespace MidPrac5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TireEnum t = new TireEnum("C:\\Users\\malik\\source\\repos\\MidPrac5\\input.txt");
            t.first();

            List<tireData> output = new List<tireData>();
            while (!t.end())
            {
                output.Add(t.current());
                t.next();
            }
    
            foreach(var i in output)
            {
                Console.WriteLine($"{i.year}: {i.tireChange}");
            }
        }
    }
}