namespace Lab06
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Bank t = new Bank("C:/Users/malik/source/repos/Lab06/input.txt");
            
            for(t.first(); !t.end(); t.next())
            {
                if(t.current() <= 1000)
                {
                    Console.WriteLine("FSDFSDfd");
                }
                
            }
        }
    }
}